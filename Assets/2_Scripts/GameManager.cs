using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore = 10;
    public static int score;
    public float currentTime;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime;
    private bool GameClearObj;
    private bool GameOverObj;
    public static int BestScore;
    [HideInInspector] public static float MinTIme = 100f;
    [HideInInspector] public static float myTime;

    //사운드
    [SerializeField] AudioClip appleSound;
    [SerializeField] AudioClip BerrySound;
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioSource MyAudioSourse;

    public bool IsGameDone
    {
        get
        {
            if (GameClearObj || GameOverObj)
            {
                //베스트 타임 저장
                if (MinTIme >= myTime)
                {
                    MinTIme = myTime;
                    PlayerPrefs.SetFloat("BestTime", MinTIme);

                }
                //클리어 씬으로
                SceneManager.LoadScene("ClearScene");
                return true;

            }

            else
            {

                return false;
            }

        }
    }

    private void Awake()
    {
        Instance = this;
        MyAudioSourse = GetComponent<AudioSource>();

    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TImeCoroutien());

        //BGM 재생
        MyAudioSourse.PlayOneShot(BGM);

    }

    IEnumerator TImeCoroutien()
    {
        while (currentTime < maxtime)
        {
            currentTime += Time.deltaTime;
            myTime = currentTime;
            UIManager.Instance.OnTimerChange(currentTime, maxtime);
            yield return null;

            if (IsGameDone)
            {
                score = 0;
                yield break;

            }
        }

        //GameOver 문구 출력
        GameOverObj = true;

        //최고 점수 저장
        if (BestScore < score)
        {
            BestScore = score;
        }

        //게임오버 씬으로
        SceneManager.LoadScene("GameOverScene");
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            //스코어 업
            score++;
            nextNoteGroupUnlockCnt++;

            //사운드 출력
            MyAudioSourse.PlayOneShot(appleSound);

            if (NoteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            if (maxScore <= score)
            {
                //Game Clear 문구 출력
                GameClearObj = true;
            }
        }
        else
        {
            //스코어 다운
            score--;

            //사운드 출력
            MyAudioSourse.PlayOneShot(BerrySound);
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}