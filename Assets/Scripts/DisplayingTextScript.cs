using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayingTextScript : MonoBehaviour
{
    private TextMeshPro displayTxtMesh;

    public string contentString;
    public bool isEffectActive;

    private float typeTimer;
    private float typeDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        displayTxtMesh = this.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEffectActive)
        {
            typeTimer += Time.deltaTime;

            displayTxtMesh.text = contentString.Substring(0, (int)(((float)contentString.Length) * typeTimer / typeDuration));
        }

    }

    public void TriggerEffect()
    {
        if (!isEffectActive)
        {
            typeTimer = 0f;
            isEffectActive = true;
            displayTxtMesh.text = "";
        }
    }
}
