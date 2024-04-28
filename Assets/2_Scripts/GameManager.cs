using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime;
    [SerializeField] private GameObject GameClearObj;
    [SerializeField] private GameObject GameOverObj;
    [SerializeField] AudioClip appleSound;
    [SerializeField] AudioClip BerrySound;
    [SerializeField] AudioSource MyAudioSourse;
    public GameObject pop;

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
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        GameClearObj.SetActive(false);
        GameOverObj.SetActive(false);

        StartCoroutine(TImeCoroutien());

    }

    IEnumerator TImeCoroutien()
    {
        float currentTime = 0f;

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

        //GameOver
        GameOverObj.SetActive(true);
        SceneManager.LoadScene("GameOverScene");
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            //사운드 출력

            MyAudioSourse.PlayOneShot(appleSound);

            //이펙트 애니메이션

            GameObject NewPop = Instantiate(pop);
            NewPop.transform.position = new Vector3(0.49f,- 19.91f,0f);

            Destroy(NewPop, 0.5f);

            //0.49 -19.91

            if (NoteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            if (maxScore <= score)
            {
                //Game Clear
                GameClearObj.SetActive(true);
            }
        }
        else
        {
            score--;

            //사운드 출력
            MyAudioSourse.PlayOneShot(BerrySound);
        }
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}