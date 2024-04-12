using System.Collections;
using UnityEngine;

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
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

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
        }
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}