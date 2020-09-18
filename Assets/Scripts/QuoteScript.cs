using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuoteType { AS_YOUR_ROBO , OUR_LEADER_IS, WE_SHOULD_INVEST, WE_MUST_NEVER_SUBMIT }

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
