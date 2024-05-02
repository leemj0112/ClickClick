using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    void Start()
    {
        GetComponent<Text>().text = "최고 점수 : " + GameManager.BestScore.ToString("N0") + "점";
    }


    void Update()
    {
        
    }
}
