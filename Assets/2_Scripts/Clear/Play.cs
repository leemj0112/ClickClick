using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "���� ��� : " + GameManager.myTime.ToString("N0") +"��";
    }

    void Update()
    {
       
    }
}
