using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
  
    void Start()
    {
       GetComponent<Text>().text = "Best Score : " + GameManager.score.ToString();
    }

  
    void Update()
    {

    }
}
