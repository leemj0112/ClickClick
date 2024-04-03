using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour
{

    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite BlueBarrySprite;

    internal void SetSprite(bool isApple)
    {
        SpriteRenderer.sprite = isApple ? appleSprite : BlueBarrySprite;
    }

    public  void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
