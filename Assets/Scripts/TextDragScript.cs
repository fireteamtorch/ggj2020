using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDragScript : MonoBehaviour
{
    private Collider2D thisCol2D;
    private Rigidbody2D thisRigid2D;

    [SerializeField] private bool isDragging;
    private Vector3 offsetVector;

    private void Awake()
    {
        thisRigid2D = this.GetComponent<Rigidbody2D>();
        thisCol2D = this.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isDragging) {
            isDragging = false;
        }

        if (isDragging)
        {
            this.transform.position = offsetVector + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            thisRigid2D.AddRelativeForce(new Vector2(-1f * thisRigid2D.mass, 0f));
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            offsetVector = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}
