using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour
{
    [SerializeField] private Animation anima;
    public void OnClick()
    {
            anima.Play();
    }
}
