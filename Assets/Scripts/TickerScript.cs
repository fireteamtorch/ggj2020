using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickerScript : MonoBehaviour
{
    public TickerItemScript tickerItemPrefab;
    public float itemDuration = 10.0f;
    public string[] fillerItems;

    private float width;
    private float pixelsPerSec;
    private TickerItemScript currentItem;

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSec = width / itemDuration;
        AddTickerItem("");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem.GetXPosition <= -currentItem.GetWidth)
        {
            AddTickerItem(fillerItems[Random.Range(0, fillerItems.Length)]);
        }
    }

    void AddTickerItem(string msg)
    {
        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.Initialize(width, pixelsPerSec, msg);
    }
}
