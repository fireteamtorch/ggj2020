using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhaseEnum { INTRO, INPUT, QUOTE_REVEAL, SCORING }

public class DirectorGame : MonoBehaviour
{
    public int maxRemovesAllowed;   // REPAIR
    public int maxInsertsAllowed;   // REORDER
    public int maxMovesAllowed;     // REPHRASE

    public int currentRemoveCount;
    public int currentInsertsCount;
    public int currentMovesCount;

    private DirectorText textDirector;

    public bool isSubmitted;

    public GamePhaseEnum currentGamePhase;

    public float phaseTimer;
    private float phaseThreshold;

    private Vector3 onScreenQuotePos;
    private Vector3 offScreenQuotePos;

    [SerializeField] private GameObject repairUIAnchor;


    private Vector3 onScreenDialoguePos;
    private Vector3 offScreenDialoguePos;
    [SerializeField] private GameObject dialogueAnchor;


    public DisplayingTextScript displayScript;

    // Start is called before the first frame update
    void Start()
    {
        onScreenQuotePos = new Vector3(0.24f, -0.99f, 0f);
        offScreenQuotePos = new Vector3(0.24f, 10f, 0f);

        onScreenDialoguePos = new Vector3(0f, -4.6f, -2f);
        offScreenDialoguePos = new Vector3(0f, -10f, -2f);

        textDirector = GameObject.FindObjectOfType<DirectorText>();
        maxRemovesAllowed = 2;
        currentRemoveCount = 0;

        // Test
        AudioHandlerScript audioScript = GameObject.Find("AudioHandler").GetComponent<AudioHandlerScript>();
        audioScript.startElectronicMusic();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTimers();
        ProcessGameState();
    }

    //public void Attempt

    public bool ReportDeleteAttempt()
    {
        if (!isSubmitted)
        {
            if (currentRemoveCount < maxRemovesAllowed)
            {
                currentRemoveCount++;
                return true;
            }
            return false;
        }
        return false;
    }

    public void ReportRemoveCancelled()
    {
        if (!isSubmitted)
        {
            currentRemoveCount--;
        }
    }

    public bool ReportMoveAttempt()
    {
        return false;
    }

    public bool ReportInsertAttempt()
    {
        return false;
    }

    public void ReportSubmitted()
    {
        if (!isSubmitted)
        {
            isSubmitted = true;
            textDirector.ProcessSubmission();
        }
    }

    public void ProcessTimers()
    {
        phaseTimer += Time.deltaTime;

        switch (currentGamePhase)
        {
            case GamePhaseEnum.INTRO:
                phaseThreshold = 3f;
                break;

            case GamePhaseEnum.QUOTE_REVEAL:
                phaseThreshold = 4f;
                break;

            case GamePhaseEnum.SCORING:
                phaseThreshold = 1f;
                break;

            default:
                phaseThreshold = Mathf.Infinity;
                break;
        }

        if(phaseTimer > phaseThreshold)
        {
            phaseTimer = 0f;
            /*
            switch (currentGamePhase)
            {
                case GamePhaseEnum.INTRO:
                    currentGamePhase = GamePhaseEnum.INPUT;
                    break;
            }
            */

        }
    }

    public void ProcessGameState()
    {
        switch (currentGamePhase)
        {
            case GamePhaseEnum.INPUT:
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
}
