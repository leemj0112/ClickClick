using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            anim.CrossFade("Idle", 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.CrossFade("Attack", 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.CrossFade("Death", 0, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.CrossFade("Walking", 0, 0);
        }
    }
}
