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

    //����
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
                //����Ʈ Ÿ�� ����
                if (MinTIme >= myTime)
                {
                    MinTIme = myTime;
                    PlayerPrefs.SetFloat("BestTime", MinTIme);

                }
                //Ŭ���� ������
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

        //BGM ���
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

        //GameOver ���� ���
        GameOverObj = true;

        //�ְ� ���� ����
        if (BestScore < score)
        {
            BestScore = score;
        }

        //���ӿ��� ������
        SceneManager.LoadScene("GameOverScene");
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            //���ھ� ��
            score++;
            nextNoteGroupUnlockCnt++;

            //���� ���
            MyAudioSourse.PlayOneShot(appleSound);

            if (NoteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            if (maxScore <= score)
            {
                //Game Clear ���� ���
                GameClearObj = true;
            }
        }
        else
        {
            //���ھ� �ٿ�
            score--;

            //���� ���
            MyAudioSourse.PlayOneShot(BerrySound);
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}