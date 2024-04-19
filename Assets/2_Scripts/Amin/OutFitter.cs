using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutFitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType chartype;

    private enum CharacterType
    {
        Ork,
        Bandit
    }
    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }

    void Update()
    {
     if (Input.GetKeyUp(KeyCode.Space)) {
            chartype = chartype == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOutFit();      
        }   
    }

    private void ChangeOutFit()
    {
        foreach(SpriteResolver resolver in resolvers)
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), chartype.ToString());

            //Bnadit만 무기 가지도록 하기

            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            Debug.Log($"sprite :{ sprite}");
                }
        }
    }

