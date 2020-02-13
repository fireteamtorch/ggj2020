using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GamePhaseEnum { INTRO, QUOTE_INTRO, INPUT, QUOTE_REVEAL, SCORING }

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
    private TextMeshPro dialogueText;


    public DisplayingTextScript startDisplayScript;
    private SpriteRenderer startDisplayPortraitSprRend;
    public DisplayingTextScript finishedDisplayScript;
    private SpriteRenderer finishedDisplayPortraitSprRend;

    public GameObject startQuoteAnchor;
    public GameObject finishedQuoteAnchor;

    private Vector3 onScreenDisplayQuotePos;
    private Vector3 offScreenDisplayQuotePos;

    [SerializeField] private GameObject newsButton;


    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogueAnchor.GetComponentInChildren<TextMeshPro>();
        onScreenQuotePos = new Vector3(0.24f, -0.99f, 0f);
        offScreenQuotePos = new Vector3(0.24f, 10f, 0f);

        onScreenDialoguePos = new Vector3(0f, -4.6f, -4f);
        offScreenDialoguePos = new Vector3(0f, -10f, -4f);

        onScreenDisplayQuotePos = new Vector3(0f, 0f, 0f);
        offScreenDisplayQuotePos = new Vector3(0f, -10f, 0f);

        textDirector = GameObject.FindObjectOfType<DirectorText>();
        maxRemovesAllowed = 2;
        currentRemoveCount = 0;


        startDisplayPortraitSprRend = startQuoteAnchor.GetComponentInChildren<SpriteRenderer>();
        finishedDisplayPortraitSprRend = finishedQuoteAnchor.GetComponentInChildren<SpriteRenderer>();
        // Test
        //AudioHandlerScript audioScript = GameObject.Find("AudioHandler").GetComponent<AudioHandlerScript>();
        //if (audioScript != null)
        //{
        //    audioScript.startElectronicMusic();
        //}
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
                phaseThreshold = 1f;
                break;

            case GamePhaseEnum.QUOTE_INTRO:
                phaseThreshold = 5f;
                break;

            case GamePhaseEnum.QUOTE_REVEAL:
                phaseThreshold = 5f;
                break;

            case GamePhaseEnum.SCORING:
                phaseThreshold = 1f;
                break;

            default:
                phaseThreshold = Mathf.Infinity;
                break;
        }

        if (phaseTimer > phaseThreshold)
        {
            phaseTimer = 0f;

            switch (currentGamePhase)
            {
                case GamePhaseEnum.INTRO:
                    maxRemovesAllowed = textDirector.quoteFramesList[0].removeCount;
                    maxMovesAllowed = textDirector.quoteFramesList[0].reorderCount;
                    maxInsertsAllowed = textDirector.quoteFramesList[0].rephraseCount;

                    startDisplayScript.contentString = textDirector.quoteFramesList[0].startQuote;
                    startDisplayScript.TriggerEffect(0.5f);
                    startDisplayPortraitSprRend.sprite = textDirector.quoteFramesList[0].portraitSprite;
                    finishedDisplayPortraitSprRend.sprite = textDirector.quoteFramesList[0].portraitSprite;
                    dialogueText.text = textDirector.quoteFramesList[0].editorDialogueText;
                    currentGamePhase = GamePhaseEnum.QUOTE_INTRO;
                    break;

                case GamePhaseEnum.QUOTE_INTRO:
                    currentGamePhase = GamePhaseEnum.INPUT;

                    break;
            }


        }
    }

    public void ProcessGameState()
    {
        switch (currentGamePhase)
        {
            case GamePhaseEnum.QUOTE_INTRO:
                startQuoteAnchor.transform.position = Vector3.Lerp(startQuoteAnchor.transform.position, onScreenDisplayQuotePos, Time.deltaTime * 5f);
                break;

            case GamePhaseEnum.INPUT:
                startQuoteAnchor.transform.position = Vector3.Lerp(startQuoteAnchor.transform.position, offScreenDialoguePos, Time.deltaTime * 5f);
                textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position = Vector3.Lerp(textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position, onScreenQuotePos, Time.deltaTime * 5f);
                dialogueAnchor.transform.position = Vector3.Lerp(dialogueAnchor.transform.position, onScreenDialoguePos, Time.deltaTime * 5f);
                if (!repairUIAnchor.activeSelf)
                {
                    repairUIAnchor.SetActive(true);
                }

                if (textDirector.isFinishedProcessingSubmission)
                {
                    currentGamePhase = GamePhaseEnum.QUOTE_REVEAL;
                    finishedDisplayScript.contentString = textDirector.submittedString;
                    finishedDisplayScript.TriggerEffect(0.5f);
                }
                break;

            case GamePhaseEnum.QUOTE_REVEAL:
                if (repairUIAnchor.activeSelf)
                {
                    repairUIAnchor.SetActive(false);
                }
                finishedQuoteAnchor.transform.position = Vector3.Lerp(finishedQuoteAnchor.transform.position, onScreenDisplayQuotePos, Time.deltaTime * 5f);
                dialogueAnchor.transform.position = Vector3.Lerp(dialogueAnchor.transform.position, offScreenDialoguePos, Time.deltaTime * 5f);
                textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position = Vector3.Lerp(textDirector.quoteFramesList[(int)textDirector.selectedQuoteType].transform.position, offScreenQuotePos, Time.deltaTime * 5f);
                newsButton.SetActive(true);
                break;

            default:
                break;
        }
    }
}
