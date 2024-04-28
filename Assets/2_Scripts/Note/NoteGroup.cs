using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject NotePrefab;
    [SerializeField] private GameObject NoteSpawn;
    [SerializeField] private float NoteGap = 6f;

    [SerializeField] private SpriteRenderer BtnspriteRenderer;
    [SerializeField] private Sprite NormalBtnSprite;
    [SerializeField] private Sprite SelectBtnSprite;
    [SerializeField] private Animation amin;
    [SerializeField] private TextMeshPro KeyCodeTmp;
    public GameObject PopEffact;
    public GameObject PopEffact2;
    private KeyCode keyCode;

    public  KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode; 
        KeyCodeTmp.text = keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.Instance.AbbKeyCode(KeyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject NoteGameOdj = Instantiate(NotePrefab);

        NoteGameOdj.transform.SetParent(NoteSpawn.transform);
        NoteGameOdj.transform.localPosition = Vector3.up * this.noteList.Count * NoteGap;
        Note note = NoteGameOdj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {
        if (noteList.Count == 0)
            return;

        //노트 삭제
        Note denote = noteList[0];
        denote.GiveScoreAndDeleteNote();
        noteList.RemoveAt(0);

        //노트 이펙트

        if (isApple)
        {
            GameObject NewPop = Instantiate(PopEffact);
            NewPop.transform.localPosition = new Vector3(0f, -19.91f, 0f);

            Destroy(NewPop, 0.5f);
        }
        else
        {
            GameObject NewPop = Instantiate(PopEffact2);
            NewPop.transform.localPosition = new Vector3(0f, -19.91f, 0f);

            Destroy(NewPop, 0.5f);
        }

        //줄 내려오기
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * NoteGap;

        //생성
        CreateNote(isApple);

        //노트 애니메이션
        amin.Play();
        BtnspriteRenderer.sprite = SelectBtnSprite;
    }

    public void callAniDone()
    {
        BtnspriteRenderer.sprite = NormalBtnSprite;
    }
}
