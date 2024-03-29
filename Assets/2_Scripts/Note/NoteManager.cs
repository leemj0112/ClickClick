using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private NoteGroup[] NoteGrouparr;

    private void Awake()
    {
        Instance = this;
    }

    public void OnInput(KeyCode keyCode)
    {
        if (keyCode == KeyCode.A) 
        {
            NoteGrouparr[0].OnInput(true);
        }
        if (keyCode == KeyCode.S)
        {
            NoteGrouparr[1].OnInput(true);
        }
    }
}
