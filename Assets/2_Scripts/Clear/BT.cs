using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "�ְ� ��� :" + GameManager.MinTIme.ToString("N0") + "��";
    }

    void Update()
    {
        
    }
}
