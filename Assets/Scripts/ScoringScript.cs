using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetScore(string txt, QuoteType quote)
    {
        switch (quote)
        {
            case QuoteType.WE_MUST_SUBMIT:
                return doScore(txt,
                    a("we must submit", "they would never take away", "only they can lead us"),
                    a()
                    );
            case QuoteType.AS_YOUR_ROBO:
                return doScore(txt,
                    a("i will spare"),
                    a("and bloody")
                    );
            case QuoteType.HUMANS_ARE_FUNDAMENTALLY:
                return doScore(txt,
                    a("i believe", "are fundamentally inferior", "and call for their"),
                    a("there are many who", "are ultimately misguided")
                    );
            default:
                return 0;
        }  
    }

    private static string[] a(params string[] args) {
        return args;
    }

    private static int doScore(string input, string[] has, string[] hasnt)
    {
        string txt = input.ToLower();
        int partialCredit = 100 / (has.Length + hasnt.Length);
        int score = 100 - partialCredit * has.Length;
        foreach(string s in has)
        {
            if (txt.Contains(s))
            {
                score += partialCredit;
            }
        }
        foreach(string s in hasnt)
        {
            if (txt.Contains(s))
            {
                score -= partialCredit;
            }
        }
        return score;
    }


}
