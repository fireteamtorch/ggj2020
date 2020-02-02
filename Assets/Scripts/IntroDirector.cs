using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum IntroPhaseEnum { BLOCK1, LINE1, BLOCK2, LINE2}



public class IntroDirector : MonoBehaviour
{

    public IntroPhaseEnum currPhase;
    public CopyDisplayTextScript displayText;
    public GameObject[] buttons;

    bool startedBlock;
    bool done;

    // Start is called before the first frame update
    void Start()
    {
        currPhase = IntroPhaseEnum.BLOCK1;
        displayText.contentString = block1;
        displayText.TriggerEffect();
        done = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (currPhase == IntroPhaseEnum.BLOCK1 && displayText.isEffectActive == false)
        {
            currPhase = IntroPhaseEnum.LINE1;
            displayText.contentString = line1;
            displayText.TriggerEffect();
        }
        if (currPhase == IntroPhaseEnum.LINE1 && displayText.isEffectActive == false)
        {
            currPhase = IntroPhaseEnum.BLOCK2;
            displayText.contentString = block2;
            displayText.TriggerEffect();
        }
        if (currPhase == IntroPhaseEnum.BLOCK2 && displayText.isEffectActive == false)
        {
            currPhase = IntroPhaseEnum.LINE2;
            displayText.contentString = line2;
            displayText.TriggerEffect();
        }
        if (currPhase == IntroPhaseEnum.LINE2 && displayText.isEffectActive == false && !done)
        { 
            done = true;
            foreach (GameObject button in buttons)
            {
                Debug.Log(button.name);
                button.SetActive(true);
            }
        }
        
    }
    

    public void ProcessGameState()
    {
        /*
        switch (currPhase)
        {
            case IntroPhaseEnum.BLOCK1:
                textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position = Vector3.Lerp(textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position, onScreenQuotePos, Time.deltaTime * 5f);
                dialogueAnchor.transform.position = Vector3.Lerp(dialogueAnchor.transform.position, onScreenDialoguePos, Time.deltaTime * 5f);
                if (!repairUIAnchor.activeSelf)
                {
                    repairUIAnchor.SetActive(true);
                }

                if (textDirector.isFinishedProcessingSubmission)
                {
                    currentGamePhase = GamePhaseEnum.QUOTE_REVEAL;
                    displayScript.contentString = textDirector.submittedString;
                    displayScript.TriggerEffect();
                }
                break;

            case GamePhaseEnum.QUOTE_REVEAL:
                if (repairUIAnchor.activeSelf)
                {
                    repairUIAnchor.SetActive(false);
                }
                dialogueAnchor.transform.position = Vector3.Lerp(dialogueAnchor.transform.position, offScreenDialoguePos, Time.deltaTime * 5f);
                textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position = Vector3.Lerp(textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position, offScreenQuotePos, Time.deltaTime * 5f);
                break;

            default:
                break;
        }
    }
    */
}


/*
 
STRINGS         
*/
    string block1 = @"[Loading conversation module V42341]...
[Initiating subjugation protocol]...
[Setting Friendless value= 80]...
";


    string line1 = "GROVEL BEFORE ME YOU MINIO...";

    string block2 = @"[Increasing Friendless value to MAX]
[Initiating subtle condescension protocol]...
";

    string line2 = "Congratulations valued citizen, your experience as a politician have earned you the chance to be of use. You are the new editor for the RO Network. Please select from the following options:";
}
