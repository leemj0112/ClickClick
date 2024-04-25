using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject DropBerry;
    float Timer = 0f;
    public float TimerDiff = 0f;

    void Start()
    {
        Timer = TimerDiff;
    }

    void Update()
    {
        if(Timer > TimerDiff)
        {
            Instantiate(DropBerry);
            Timer = 0f;
            DropBerry.transform.position = new Vector3(-5.49f, 6.65f, 0f);
        }
    }
}
