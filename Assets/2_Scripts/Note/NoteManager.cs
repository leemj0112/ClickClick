using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject NoteGroupPrefab;
    [SerializeField] private float noteGroupGab = 11;
    [SerializeField] AudioClip CreateSound;
    [SerializeField] AudioSource CreateAudioSourse;
    [SerializeField] Animator animation;

    [SerializeField]
    private KeyCode[] wholeKeyCodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F,
        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K,KeyCode.L
    };

    [SerializeField] private int intNoteGroupNum = 2;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
        CreateAudioSourse = GetComponent<AudioSource>();
        animation = GetComponent<Animator>();
    }

    public void Not()
    {
        animation.CrossFade("Noteanim", 0, 0);
    }

    public void Star()
    {
        animation.CrossFade("Starpaly", 2f);
        Invoke("Not", 2f);
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        KeyCode keyCode = this.wholeKeyCodeArr[noteGroupCount];
        CreateNoteGroup(keyCode);

        CreateAudioSourse.PlayOneShot(CreateSound);
        Star();
    }

    public void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(NoteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGab;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);

    }


    public void Create()
    {
        for (int i = 0; i < intNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodeArr[i]);
        }
    }

    public void OnInput(KeyCode keyCode)
    {
        int randid = Random.Range(0, 2);
        bool isApple = randid == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
    }
}
