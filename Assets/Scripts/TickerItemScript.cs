using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickerItemScript : MonoBehaviour
{
    float tickerWidth;
    float pixelsPerSec;
    RectTransform rt;

    public float GetXPosition { get { return rt.anchoredPosition.x; } }
    public float GetWidth { get { return rt.rect.width; } }

    public void Initialize(float tickerWidth, float pixelsPerSec, string msg)
    {
        this.tickerWidth = tickerWidth;
        this.pixelsPerSec = pixelsPerSec;
        this.rt = GetComponent<RectTransform>();
        GetComponent<Text>().text = msg;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rt.position += Vector3.left * pixelsPerSec * Time.deltaTime;
        if (GetXPosition <= 0 - tickerWidth - GetWidth)
        {
            Destroy(gameObject);
        }
    }
}
