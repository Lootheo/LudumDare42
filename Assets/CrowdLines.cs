using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdLines : MonoBehaviour {
    public List<Character> rightLine, leftLine;

    TapEvents TapEvents;
    public GameObject characterPrefab;

    public void Start()
    {
        TapEvents = FindObjectOfType<TapEvents>();
        rightLine[0].side = Side.Right;
        rightLine[1].side = Side.Right;
        rightLine[2].side = Side.Right;

        leftLine[0].side = Side.Left;
        leftLine[1].side = Side.Left;
        leftLine[2].side = Side.Left;
        AssignLineCharacters();

    }

    public void ProceedLine(int side)
    {
        if (side == 0)
        {
            ProceedLineCurrent(leftLine, Side.Left);
        }
        else
        {
            ProceedLineCurrent(rightLine, Side.Right);
        }
        AssignLineCharacters();
    }


    public void ProceedLineCurrent(List<Character> currentLine, Side _side){
        GameObject newCitizen = Instantiate(characterPrefab, currentLine[2].transform.position, Quaternion.identity);
        SwapPlaces(currentLine[2], currentLine[1]);
        SwapPlaces(currentLine[1], currentLine[0]);
        Destroy(currentLine[0].gameObject);
        currentLine[0] = currentLine[1];
        currentLine[1] = currentLine[2];
        currentLine[2] = newCitizen.GetComponent<Character>();
        currentLine[2].side = _side;

    }
    public void SwapPlaces(Character originGO, Character destinyGO)
    {
        originGO.transform.position = destinyGO.transform.position;
        originGO.GetComponent<Character>().startPosition= originGO.transform.position;
    }


    public void AssignLineCharacters()
    {
        TapEvents.frontCharacters[0] = leftLine[0];
        TapEvents.DisplayInfo(leftLine[0]);
        TapEvents.frontCharacters[1] = rightLine[0];
        TapEvents.DisplayInfo(rightLine[0]);
    }

}
