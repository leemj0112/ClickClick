using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject NotePrefab;
    [SerializeField] private GameObject NoteSpawn;
    [SerializeField] private float NoteGap = 6f;

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

    void Update()
    {

    }
}
