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

        //BGM ���
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

        //GameOver ���� ���
        GameOverObj.SetActive(true);

        //����Ʈ ���� ����
        if (BestScore >= score)
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
                GameClearObj.SetActive(true);

                //����Ʈ �ð� ����
                if (BestTime <= currentTime)
                {
                    BestTime = currentTime;
                }

                Debug.Log($"{BestTime:N0}");

                //���� Ŭ���� ������
                SceneManager.LoadScene("ClearScene");
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