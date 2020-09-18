using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum QuoteType { QUOTE_1, QUOTE_2 , QUOTE_3 }

public class DirectorText : MonoBehaviour
{
    public List<QuoteScript> quoteFramesList;
    public List<string> quotesRefList;

    public QuoteType selectedQuoteType;

    public int quotePlayerScore;
    public int quoteMaxScore;

    public string submittedString;
    public int submissionScore;
    public string gradingString;

    public bool isFinishedProcessingSubmission;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AttemptConcatenateAllText();
        }
    }

    public void AttemptConcatenateAllText()
    {
        //TextDragScript[] allTextScripts = GameObject.FindObjectsOfType<TextDragScript>(); // Grabs every TextDragScript in the scene
        TextDragScript[] allTextScripts = quoteFramesList[(int)selectedQuoteType].dragList;
        List<TextDragScript> tempTextsList = new List<TextDragScript>();
        List<TextDragScript> tempOutputList = new List<TextDragScript>();
        foreach (TextDragScript tempScript in allTextScripts)
        {
            Debug.Log("Found: " + tempScript.gameObject.name);
            tempTextsList.Add(tempScript);
        }

        while (tempTextsList.Count > 0)
        {
            if (tempTextsList.Count > 1)
            {
                TextDragScript highestScript = tempTextsList[0];
                int highestSlot = 0;
                for (int n = 1; n < tempTextsList.Count; n++)
                {
                    TextDragScript tempDrag = tempTextsList[n];

                    Debug.Log(tempDrag.name + tempDrag.transform.position.ToString() + " TO " + highestScript.name + highestScript.transform.position.ToString());
                    if (tempDrag.transform.position.y - highestScript.transform.position.y > 0.6f)
                    {
                        highestScript = tempTextsList[n];
                        highestSlot = n;
                    }
                    else if (Mathf.Abs(tempDrag.transform.position.y - highestScript.transform.position.y) < 0.2f && (tempDrag.transform.position.x < highestScript.transform.position.x))
                    {
                        highestScript = tempTextsList[n];
                        highestSlot = n;
                    }
                }
                Debug.Log("Added: " + highestScript.gameObject.name);
                tempOutputList.Add(highestScript);
                tempTextsList.RemoveAt(highestSlot);
            }
            else
            {
                tempOutputList.Add(tempTextsList[0]);
                tempTextsList.Clear();
            }
        }

        string outputString = "";
        string cleanStringToGrade = "";
        foreach (TextDragScript tempScript in tempOutputList)
        {
            TextDeleteScript tempDeleteScript = tempScript.gameObject.GetComponent<TextDeleteScript>();
            TextDragScript tempDragScript = tempScript.gameObject.GetComponent<TextDragScript>();
            if ((tempDragScript != null && tempDragScript.isDragable))
            {
                outputString += "-" + tempScript.gameObject.name + "- ";
                cleanStringToGrade += tempScript.gameObject.name + " ";
            }
            else if((tempDeleteScript != null && tempDeleteScript.isDeleted)) {
                outputString += "[...] ";
                //cleanStringToGrade;
            }
            else 
            {
                outputString += tempScript.gameObject.name + " ";
                cleanStringToGrade += tempScript.gameObject.name + " ";
            }
        }

        Debug.Log("FINAL OUTPUT: " + outputString);


        //ScoreQuote(outputString);

        submittedString = outputString;

        isFinishedProcessingSubmission = true;

        ScoreQuote(outputString, selectedQuoteType);
        gradingString = cleanStringToGrade;
        Debug.Log("To grade:" + gradingString);

        
        SceneVariableManager.editedQuote = cleanStringToGrade;
    }

    private void ScoreQuote(string concatenatedText, QuoteType quoteType)
    {
        string rubricString = quotesRefList[(int)selectedQuoteType];

        Debug.Log("Player Quote: " + concatenatedText);
        Debug.Log("Quote to grade to : " + rubricString);

        switch (selectedQuoteType)
        {
            case QuoteType.AS_YOUR_ROBO: // Can make unique grading criteria for the test quote here 

                // grade here

                // set these to score actual values
                quotePlayerScore = 10;
                quoteMaxScore = 10;


                break;

            default:
                quoteMaxScore = 0;
                quotePlayerScore = 0;
                break;
        }
    }

    public void ProcessSubmission()
    {
        AttemptConcatenateAllText();
        //quotePlayerScore = ScoringScript.GetScore(concatenatedText, quoteType);

        Debug.Log("Scored out of 100: " + quotePlayerScore);

    }
}
