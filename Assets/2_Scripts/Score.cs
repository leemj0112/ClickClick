using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        GetComponent<Text>().text = "Best Score : " + GameManager.Instance.BestScore;
    }
}
