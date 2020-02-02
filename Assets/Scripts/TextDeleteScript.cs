using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDeleteScript : MonoBehaviour
{
    public bool isDeleteable;
    public bool isDeleted;

    private SpriteRenderer sprRend;
    private Collider2D thisCol2D;
    private TextMesh txtMesh;

    private bool isAttemptingClick;
    private float clickTimer;
    private float clickThreshold = 0.17f;

    private DirectorGame gameDirector;

    private void Awake()
    {
        gameDirector = GameObject.FindObjectOfType<DirectorGame>();
        sprRend = this.GetComponentInChildren<SpriteRenderer>();
        thisCol2D = this.GetComponent<Collider2D>();
        txtMesh = this.GetComponentInChildren<TextMesh>();
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
            txtMesh.color = Color.Lerp(Color.white, Color.black, 0.6f);
            sprRend.color = Color.gray;
        }
        else
        {
            txtMesh.color = Color.Lerp(Color.white, Color.black, 0f);
            sprRend.color = Color.black;
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
        }

        if (Input.GetMouseButtonUp(0) && isAttemptingClick && clickTimer < clickThreshold)
        {
            //TODO REPORT REMOVE ATTEMPT HERE
            if (!isDeleted && gameDirector.ReportDeleteAttempt())
            {
                isDeleted = true;
            } else if (isDeleted)
            {
                gameDirector.ReportRemoveCancelled();
                isDeleted = false;
            }
            isAttemptingClick = false;
        }
    }

    private void OnMouseExit()
    {
        isAttemptingClick = false;
    }
}
