using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuoteType { TEST_QUOTE, QUOTE_1 , QUOTE_2}

public class QuoteScript : MonoBehaviour
{
    public QuoteType thisQuoteType;

    public TextDragScript[] dragList;
    public TextDeleteScript[] deleteList;

    private void Awake()
    {
        dragList = this.GetComponentsInChildren<TextDragScript>();
        deleteList = this.GetComponentsInChildren<TextDeleteScript>();
    }

}
