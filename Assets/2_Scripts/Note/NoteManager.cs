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
        int randid = Random.Range(0, NoteGrouparr.Length);
        bool isApple = randid == 0 ? true : false;

        foreach (NoteGroup noteGroup in NoteGrouparr)
        {
            if(keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}
