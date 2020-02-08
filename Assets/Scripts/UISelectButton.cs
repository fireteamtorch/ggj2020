using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonType { NONE, SUBMIT, NEWS_BRIEF }

public class UISelectButton : MonoBehaviour
{
    private Collider2D thisCol2D;
    private SpriteRenderer sprRend;
    private TextMesh txtMesh;

    public bool isButtonSelected;

    public ButtonType thisButtonType;

    private Color startTextColor;
    private Color startFillColor;

    private void Awake()
    {
        sprRend = this.GetComponentInChildren<SpriteRenderer>();
        startTextColor = sprRend.color;
        txtMesh = this.GetComponent<TextMesh>();
        startFillColor = txtMesh.color;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isButtonSelected)
        {
            txtMesh.color = startFillColor;
            sprRend.color = startTextColor;
        }
        else
        {
            txtMesh.color = startTextColor;
            sprRend.color = startFillColor;
        }
    }

    private void OnMouseOver()
    {
        if (!isButtonSelected && Input.GetMouseButtonDown(0))
        {
            isButtonSelected = true;
        }

        if(isButtonSelected && Input.GetMouseButtonUp(0))
        {
            OnButtonClick();
            isButtonSelected = false;
        }
    }

    private void OnMouseExit()
    {
        isButtonSelected = false;
    }

    private void OnButtonClick()
    {
        switch (thisButtonType)
        {
            case ButtonType.SUBMIT:
                (GameObject.FindObjectOfType<DirectorGame>()).ReportSubmitted();
                break;

            case ButtonType.NEWS_BRIEF:
                SceneManager.LoadScene("NewscastScene");
                break;

            default:
                break;
        }
    }

}
