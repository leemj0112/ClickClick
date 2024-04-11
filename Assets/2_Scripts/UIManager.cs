using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    [SerializeField] private Image TimerImg;
    [SerializeField] private TextMeshProUGUI TimerTmp;

    private void Awake()
    {
        Instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore} / {maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;

    }
        public void OnTimerChange(float currentTImer, float maxTImer)
        {
            TimerTmp.text = $"{currentTImer:N1} / {maxTImer:N1}";
            TimerImg.fillAmount = (float)currentTImer / maxTImer;
        }
    }