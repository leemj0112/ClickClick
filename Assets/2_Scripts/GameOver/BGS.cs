using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGS : MonoBehaviour
{
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();  
        source.Play();
    }

    void Update()
    {
        
    }
}
