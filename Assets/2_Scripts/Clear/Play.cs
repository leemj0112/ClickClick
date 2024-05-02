using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "현재 기록 : " + GameManager.myTime.ToString("N0") +"초";
    }

    void Update()
    {
       
    }
}
