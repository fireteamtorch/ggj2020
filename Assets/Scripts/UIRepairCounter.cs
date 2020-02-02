using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRepairCounter : MonoBehaviour
{
    private TextMesh txtMesh;
    private DirectorGame gameDirector;

    private int prevValue;
    private Vector3 startScale;

    private void Awake()
    {
        startScale = this.transform.localScale;
        txtMesh = this.GetComponent<TextMesh>();
        gameDirector = GameObject.FindObjectOfType<DirectorGame>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prevValue != gameDirector.maxRemovesAllowed - gameDirector.currentRemoveCount)
        {
            prevValue = gameDirector.maxRemovesAllowed - gameDirector.currentRemoveCount;
            UpdateText();
        }

        this.transform.localScale = Vector3.Lerp(this.transform.localScale, startScale, Time.deltaTime * 7f);
    }

    public void UpdateText()
    {
        txtMesh.text = prevValue + "  REPAIRS ALLOWED";
        this.transform.localScale = new Vector3(startScale.x, startScale.y * 1.8f, startScale.z);
    }
}
