using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    void Start()
    {
        GetComponent<Text>().text = "�ְ� ���� : " + GameManager.BestScore.ToString("N0") + "��";
    }


    void Update()
    {
        
    }
}
