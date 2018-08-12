using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Right ,Center}
public enum Job { None, Medic, Engineer, Soldier,Scientist,FireFighter}
public enum Gender { Male, Female }
[RequireComponent(typeof(PolygonCollider2D))]
public class Character : MonoBehaviour {
    public int age = 10;
    public bool infected = false;
    public Side side = Side.Right;
    public Job job = Job.None;
    public Gender gender = Gender.Male;
    public SpriteRenderer spriteRenderer;
    public Sprite portrait;
    

    public void SetRandomValues()
    {
        age = Random.Range(10, 90);
        //side = (Side)Random.Range(0, 2);
        infected = Random.Range(0, 5) > 3;
        job = (Job)Random.Range(0, 6);
        gender = (Gender)Random.Range(0, 2);
        name = TextsLibrary.GetRandomCharacterName(this);
        portrait = FindObjectOfType<SpriteManager>().GetRandomPortrait(this);
        AssignSprites();
        AssignSpriteProperties();
    }



    public void Awake()
    {
        SetRandomValues();
    }

    #region sprites

    public void AssignSprites()
    {
        FindObjectOfType<SpriteManager>().FillCharacterChildSprites(this);
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
            foreach(SpriteRenderer childRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                childRenderer.color = Color.green;
            }
        }
        else
        {
            foreach (SpriteRenderer childRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                childRenderer.color = Color.white;
            }
        }
    }


    public void CopyValues(Character characterToCopy)
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
            Debug.Log(name + " was infected, you did wrong");
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
            Debug.Log(name + " was not infected, you did wrong");
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
