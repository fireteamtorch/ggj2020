using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorGame : MonoBehaviour
{
    public int maxRemovalsAllowed;
    public int maxInsertsAllowed;
    public int maxMovesAllowed;

    public int currentRemoveCount;
    public int currentInsertsCount;
    public int currentMovesCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ReportDeleteAttempt()
    {
        return false;
    }

    public bool ReportMoveAttempt()
    {
        return false;
    }

    public bool ReportInsertAttempt()
    {
        return false;
    }
}
