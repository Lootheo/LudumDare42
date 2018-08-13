using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Right ,Center}
public enum Job { None, Medic, Engineer, Soldier,Scientist,FireFighter}
public enum Gender { Male, Female }
public enum Disease { None, Parkinson, Alzheimer}
public enum BodyType { Kid,Adult,Old}
[RequireComponent(typeof(PolygonCollider2D))]
public class Character : MonoBehaviour {
    public int age = 10;
    public bool infected = false;
    public Side side = Side.Right;
    public Job job = Job.None;
    public Gender gender = Gender.Male;
    public BodyType bodyType = BodyType.Adult;
    public SpriteRenderer spriteRenderer;
    public Sprite portrait;
    public List<Disease> diseases = new List<Disease>();
    public Vector3 startPosition;

    public void SetRandomValues()
    {
        age = Random.Range(0, 90);
        if(age <= 10)
        {
            bodyType = BodyType.Kid;
        }else if(age > 70)
        {
            bodyType = BodyType.Old;
        }else
        {
            bodyType = BodyType.Adult;
        }
        infected = Random.Range(0, 5) > 3;
        if (bodyType == BodyType.Adult)
        {
            job = (Job)Random.Range(0, 6);
        }
        else
        {
            job = Job.None;
        }
        gender = (Gender)Random.Range(0, 2);
        name = TextsLibrary.GetRandomCharacterName(this);
        diseases = new List<Disease>();
        if (!infected)
        {
            if (Random.Range(0, 10)>7 && bodyType == BodyType.Old)
            {
                startPosition = transform.position;
                diseases.Add(Disease.Parkinson);
            }
        }
        portrait = FindObjectOfType<SpriteManager>().GetRandomPortrait(this);
        AssignSprites();
        AssignSpriteProperties();
    }



    public void Awake()
    {
        SetRandomValues();
    }

    public void Update()
    {
        if (diseases.Contains(Disease.Parkinson))
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    public IEnumerator ShakeCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = startPosition + Random.insideUnitSphere / 20;
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