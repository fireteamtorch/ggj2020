using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDragScript : MonoBehaviour
{
    private BoxCollider2D thisCol2D;
    private Rigidbody2D thisRigid2D;

    public bool isDragable;
    [SerializeField] private bool isDragging;
    private Vector3 offsetVector;

    private Vector2 startSize;

    private void Awake()
    {
        thisRigid2D = this.GetComponent<Rigidbody2D>();
        thisCol2D = this.GetComponent<BoxCollider2D>();
        startSize = thisCol2D.size;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragable && Input.GetMouseButtonUp(0) && isDragging) {
            isDragging = false;
        }

        if (isDragging)
        {
            this.transform.position = offsetVector + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            thisRigid2D.AddRelativeForce(new Vector2(-1f * thisRigid2D.mass, 0f));
            thisCol2D.size = startSize;
        }

    }

    private void OnMouseOver()
    {
        if (isDragable && Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            offsetVector = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            thisCol2D.size = startSize * 1.5f;
        }
    }

}
