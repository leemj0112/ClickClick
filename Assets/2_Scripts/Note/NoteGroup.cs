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

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject NoteGameOdj = Instantiate(NotePrefab);

            NoteGameOdj.transform.SetParent(NoteSpawn.transform);
            NoteGameOdj.transform.localPosition = Vector3.up * this.noteList.Count * NoteGap;
            Note note = NoteGameOdj.GetComponent<Note>();

            noteList.Add(note);
        }
    }

    public void OnInput(bool v)
    {
        amin.Play();
        BtnspriteRenderer.sprite = SelectBtnSprite;
    }

    public void callAniDone()
    {
        BtnspriteRenderer.sprite = NormalBtnSprite;
    }
}
