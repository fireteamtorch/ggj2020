using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{
    /*
     * 0 = "We must never submit"
     * 
     * 
     */


    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetScore(string finalText, int id)
    {
        score = 0;
        string txt = finalText.ToLower();
        switch (id)
        {
            case 0:
                if (txt.Contains("we must submit")) {
                    score += 40;
                }
                if (txt.Contains("they would never take away"))
                {
                    score += 40;
                }
                if (txt.Contains("only they can lead us"))
                {
                    score += 20;
                }
                break;
            default:
                break;
        }
        return score;
    }


}
