using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Right ,Center}

[RequireComponent(typeof(PolygonCollider2D))]
public class TappableCharacter : MonoBehaviour {
    public int age = 10;
    public bool infected = false;
    public Side side = Side.Right;
    public SpriteRenderer spriteRenderer;

    private List<string> characterNames = new List<string>
    {
        "Melissa","Bob","Arthur","Paco","Regina","Thomas"
    };
    

    public void SetRandomValues()
    {
        age = Random.Range(10, 90);
        //side = (Side)Random.Range(0, 2);
        infected = Random.Range(0, 5) > 3;
        name = characterNames[Random.Range(0, characterNames.Count)];
        AssignSprites();
    }



    public void Awake()
    {
        SetRandomValues();
    }

    #region sprites

    public void AssignSprites()
    {
        FindObjectOfType<SpriteManager>().FillCharacterChildSprites(gameObject.transform);
    }
    public void AssignSpriteProperties()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        if (infected)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }


    public void CopyValues(TappableCharacter characterToCopy)
    {
        age = characterToCopy.age;
        infected = characterToCopy.infected;
        name = characterToCopy.name;
        side = characterToCopy.side;
    }
    #endregion
    #region events
    public void Pass()
    {
        //Debug.Log(name + " passed");
        if (!infected)
        {
            FindObjectOfType<TapEvents>().Score++;
            Debug.Log(name + " was not infected, you did right");
        }
        else
        {
            FindObjectOfType<TapEvents>().Score-=10;
            Debug.Log(name + " was not infected, you did wrong");
        }
    }
    public void Block()
    {
        Debug.Log(name + " blocked");
    }
    public void Kill()
    {
        //Debug.Log(name + " killed");
        if (infected)
        {
            FindObjectOfType<TapEvents>().Score++;
            Debug.Log(name + " was infected, you did right");
        }
        else
        {
            FindObjectOfType<TapEvents>().Score--;
            Debug.Log(name + " was infected, you did wrong");
        }
    }

    public string AskName()
    {
        if (!infected)
        {
            return (name);
        }
        else
        {
            return "WASDKg";
        }
    }

    public string AskAge()
    {
        if (!infected)
        {
            return (age.ToString());
        }
        else
        {
            return "-1";
        }
    }
    #endregion
}
