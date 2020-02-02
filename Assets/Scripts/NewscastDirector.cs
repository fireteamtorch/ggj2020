using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NewscastPhase { BREAKING_NEWS, COMMENTARY }

public class NewscastDirector : MonoBehaviour
{
    public NewscastPhase currPh;
    public GameObject[] commentators;

    public GameObject good;
    public GameObject bad;

    public Text text;
    
    void Start()
    {
        foreach (GameObject c in commentators)
        {
            c.SetActive(false);
        }
        int face = Random.Range(0, commentators.Length);
        commentators[face].SetActive(true);
        bool success = SceneVariableManager.score > 50;
        if (success)
        {
            good.SetActive(true);
            bad.SetActive(false);
            text.text = successQuotes[Random.Range(0, successQuotes.Length)];
        } else
        {
            good.SetActive(false);
            bad.SetActive(true);
            text.text = failQuotes[Random.Range(0, failQuotes.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] successQuotes =
    {
        "This just in, concept of ‘Mercy’ Major hugely popular among human population. Robot Council considering 5% reduction in unnecessary cruelty",
        "Productivity increased as the mention of ‘freedom’ galvanized the human population",
        "Age discovered to be relevant among humans. ‘Children’ appear to be hot topic among Citizens."
    };

    string[] failQuotes =
    {
        "Productivity plummet as panic broke out among the human population. Possible consequence of needless cruelty? The real victims are the Robots Overseers failing to meet quota.",
        "The new surge of support indicate human aversion to being exploited, Scientron seeking more conclusive data.",
        "Labor force diminish as the population cease to copulate, horrified by the disregard for orphans. A new workforce shortage on the horizon?"
    };

}
