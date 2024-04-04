using System.Collections.Generic;
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
    [SerializeField] private KeyCode keyCode;

    public  KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();

    private void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
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
        denote.DeleteNote();
        noteList.RemoveAt(0);

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
