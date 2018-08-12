using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdLines : MonoBehaviour {
    public List<TappableCharacter> rightLine,leftLine;

    TapEvents TapEvents;

    public void Start()
    {
        TapEvents = FindObjectOfType<TapEvents>();
        AssignLineCharacters();
    }

    public void ProceedLine(int side)
    {
        if (side == 0)
        {
            leftLine[0].CopyValues(leftLine[1]);
            leftLine[1].CopyValues(leftLine[2]);
            leftLine[2].SetRandomValues();
        }
        else
        {

            rightLine[0].CopyValues(rightLine[1]);
            rightLine[1].CopyValues(rightLine[2]);
            rightLine[2].SetRandomValues();
        }
        AssignLineCharacters();
    }


    public void AssignLineCharacters()
    {
        TapEvents.frontCharacters[0] = leftLine[0];
        TapEvents.DisplayInfo(leftLine[0]);
        TapEvents.frontCharacters[1] = rightLine[0];
        TapEvents.DisplayInfo(rightLine[0]);
    }

}
