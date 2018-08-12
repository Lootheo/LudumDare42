using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextsLibrary : MonoBehaviour {


    private static List<string> maleCharacterNames = new List<string>
    {
        "Bob","Arthur","Paco","Thomas"
    };
    private static List<string> femaleCharacterNames = new List<string>
    {
        "Melissa","Regina","Alice"
    };

    public static string GetRandomCharacterName(Character character)
    {
        if (character.gender == Gender.Male)
        {
            return maleCharacterNames[Random.Range(0, maleCharacterNames.Count)];
        }
        else
        {
            return femaleCharacterNames[Random.Range(0, femaleCharacterNames.Count)];
        }
    }
}
