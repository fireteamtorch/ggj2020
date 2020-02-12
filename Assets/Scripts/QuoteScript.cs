using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuoteType { WE_MUST_SUBMIT, AS_YOUR_ROBO , HUMANS_ARE_FUNDAMENTALLY}

public class QuoteScript : MonoBehaviour
{
    public QuoteType thisQuoteType;

    public TextDragScript[] dragList;
    public TextDeleteScript[] deleteList;

    public int removeCount;
    public int reorderCount;
    public int rephraseCount;

    public string startQuote;

    public Sprite portraitSprite;

    public string editorDialogueText;

    [SerializeField] private SpriteRenderer portraitSprRend;

    private void Awake()
    {
        dragList = this.GetComponentsInChildren<TextDragScript>();
        deleteList = this.GetComponentsInChildren<TextDeleteScript>();
        portraitSprRend.sprite = portraitSprite;
    }

}
