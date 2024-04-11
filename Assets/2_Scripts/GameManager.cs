using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore = 10;
    private int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime = 30f;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TImeCoroutien());
    }

    IEnumerator TImeCoroutien()
    {
        float currentTime = 0f;

        while (currentTime < maxtime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxScore);
            yield return null;
        }
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
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }
}