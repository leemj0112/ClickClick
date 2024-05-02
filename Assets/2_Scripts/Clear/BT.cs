using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "최고 기록 :" + GameManager.MinTIme.ToString("N0") + "초";
    }

    void Update()
    {
        
    }
}
