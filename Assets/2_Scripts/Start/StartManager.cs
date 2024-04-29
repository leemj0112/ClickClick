using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField] AudioSource StartAudioSourse;

    void Start()
    {
        StartAudioSourse = GetComponent<AudioSource>();
        StartAudioSourse.Play();
    }

    void Update()
    {

    }
}
