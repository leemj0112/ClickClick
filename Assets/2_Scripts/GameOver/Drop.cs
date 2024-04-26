using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject DropBerry;
    float Timer = 0f;
    public float TimerDiff = 2f;

    void Start()
    {
        Timer = TimerDiff;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimerDiff)
        {
            GameObject BerryClone = Instantiate(DropBerry);
            BerryClone.transform.position = transform.position;
            Timer = 0f;

            Destroy(BerryClone,2f);
        }
    }
}
