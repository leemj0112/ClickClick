using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore = 10;
    public static int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime;
    [SerializeField] private GameObject GameClearObj;
    [SerializeField] private GameObject GameOverObj;
    [SerializeField] AudioClip appleSound;
    [SerializeField] AudioClip BerrySound;
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioSource MyAudioSourse;
    public static int BestScore = 0;
    public static float BestTime = 0;
    public static float currentTime = 0f;

    public bool IsGameDone
    {
        get
        {
            if (GameClearObj.activeSelf || GameOverObj.activeSelf)
                return true;
            else
                return false;
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

        GameClearObj.SetActive(false);
        GameOverObj.SetActive(false);

        StartCoroutine(TImeCoroutien());

        //BGM 재생
        MyAudioSourse.PlayOneShot(BGM);

    }

    IEnumerator TImeCoroutien()
    {
        while (currentTime < maxtime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxtime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        //GameOver 문구 출력
        GameOverObj.SetActive(true);

        //베스트 점수 저장
        if (BestScore >= score)
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
                GameClearObj.SetActive(true);

                //베스트 시간 저장
                if (BestTime <= currentTime)
                {
                    BestTime = currentTime;
                }

                Debug.Log($"{BestTime:N0}");

                //게임 클리어 씬으로
                SceneManager.LoadScene("ClearScene");
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