using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDeleteScript : MonoBehaviour
{
    public bool isDeleteable;
    public bool isDeleted;

    private SpriteRenderer sprRend;
    private Collider2D thisCol2D;

    private bool isAttemptingClick;
    private float clickTimer;
    private float clickThreshold = 0.17f;

    private void Awake()
    {
        sprRend = this.GetComponent<SpriteRenderer>();
        thisCol2D = this.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeleted)
        {
            sprRend.color = Color.gray;
        }
        else
        {
            sprRend.color = Color.white;
        }

        if (isAttemptingClick) {
            clickTimer += Time.deltaTime;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttemptingClick = true;
            clickTimer = 0f;
            //Debug.Log("Click start");
        }

        if(Input.GetMouseButtonUp(0) && isAttemptingClick && clickTimer < clickThreshold)
        {
            isDeleted = !isDeleted;
            isAttemptingClick = false;
            //Debug.Log("CLICKED");
        }
    }

    private void OnMouseExit()
    {
        isAttemptingClick = false;
    }
}
