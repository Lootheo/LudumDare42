using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BodyPart { Head, Hair,Helmet, LeftArm, RightArm, Body, Legs }

[System.Serializable]
public struct SpecificSpriteList
{
    public Sprite headSprite;
    public Sprite hairSprite;
    public Sprite helmetSprite;
    public Sprite leftArmSprite;
    public Sprite rightArmSprite;
    public Sprite shirtSprite;
    public Sprite legsSprite;
}
public class SpriteManager : MonoBehaviour
{
    public List<Sprite> headSprites;
    [Header("Gender Features")]
    public List<Sprite> malePortraitSprites;
    public List<Sprite> femalePortraitSprites;
    
    public List<Sprite> maleShirtSprites, femaleShirtSprites;
    public List<Sprite> maleHairSprites, femaleHairSprites;
    public List<Sprite> maleLegSprites, femaleLegSprites;

    public List<Sprite> maleLeftArmSprites, femaleLeftArmSprites;
    public List<Sprite> maleRightArmSprites, femaleRightArmSprites;
    [Header("Old")]
    public List<Sprite> oldMaleHeadSprites;
    public List<Sprite> oldFemaleHeadSprites;
    [Header("Child")]
    public List<Sprite> childMaleHeadSprites;
    public List<Sprite> childFemaleHeadSprites;
    public List<Sprite> childRightArmSprites;
    public List<Sprite> childLeftArmSprites;
    public List<Sprite> childMaleLegSprites, childFemaleLegSprites;
    public List<Sprite> childMaleShirtSprites, childFemaleShirtSprites;


    [Header("Specific Outfits")]
    // cabeza, cabello, brazo izq, brazo derecho, torso, piernas (el par)
    public SpecificSpriteList medicSprites;
    public SpecificSpriteList fireFighterSprites,engineerSprites,soldierSprites,scientistSprites;
    
    public void FillCharacterChildSprites(Character character)
    {
        switch (character.job)
        {
            case Job.Medic:
                FillSpecificSprites(character.transform, medicSprites);
                break;
            case Job.Engineer:
                FillSpecificSprites(character.transform, engineerSprites);
                break;
            case Job.Soldier:
                FillSpecificSprites(character.transform, soldierSprites);
                break;
            case Job.Scientist:
                FillSpecificSprites(character.transform, scientistSprites);
                break;
            case Job.FireFighter:
                FillSpecificSprites(character.transform, fireFighterSprites);
                break;
            default:
                FillRandomSprites(character.transform);
                break;
        }
    }

    private void FillSpecificSprites(Transform parent, SpecificSpriteList specificClothesList)
    {
        FillRandomSprites(parent);
        SetSprite(parent.Find("Head"), specificClothesList.headSprite);
        SetSprite(parent.Find("Hair"), specificClothesList.hairSprite);
        SetSprite(parent.Find("Helmet"), specificClothesList.helmetSprite);
        SetSprite(parent.Find("LeftArm"), specificClothesList.leftArmSprite);
        SetSprite(parent.Find("RightArm"), specificClothesList.rightArmSprite);
        SetSprite(parent.Find("Shirt"), specificClothesList.shirtSprite);
        SetSprite(parent.Find("Legs"), specificClothesList.legsSprite);
    }

    public Sprite GetRandomPortrait(Character character)
    {
        if (character.gender == Gender.Male)
        {
            return malePortraitSprites[Random.Range(0, malePortraitSprites.Count)];
        }
        else
        {
            return femalePortraitSprites[Random.Range(0, femalePortraitSprites.Count)];
        }
    }


    public void FillRandomSprites(Transform parent)
    {
        //Central, unique sprites
        if (parent.GetComponent<Character>().bodyType == BodyType.Adult)
        {
            SetRandomSprite(parent.Find("Head"), headSprites);
            if (parent.GetComponent<Character>().gender == Gender.Male)
            {
                SetRandomSprite(parent.Find("Hair"), maleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), maleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), maleLegSprites);
                SetRandomSprite(parent.Find("RightArm"), maleRightArmSprites);
                SetRandomSprite(parent.Find("LeftArm"), maleLeftArmSprites);
            }
            else
            {
                SetRandomSprite(parent.Find("Hair"), femaleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), femaleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), femaleLegSprites);
                SetRandomSprite(parent.Find("RightArm"), femaleRightArmSprites);
                SetRandomSprite(parent.Find("LeftArm"), femaleLeftArmSprites);
            }
        }else if(parent.GetComponent<Character>().bodyType == BodyType.Kid)
        {
            if (parent.GetComponent<Character>().gender == Gender.Male)
            {
                SetRandomSprite(parent.Find("Head"), childMaleHeadSprites);
                SetRandomSprite(parent.Find("Hair"), maleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), childMaleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), childMaleLegSprites);
            }
            else
            {
                SetRandomSprite(parent.Find("Head"), childFemaleHeadSprites);
                SetRandomSprite(parent.Find("Hair"), femaleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), childFemaleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), childFemaleLegSprites);
            }
            SetRandomSprite(parent.Find("RightArm"), childRightArmSprites);
            SetRandomSprite(parent.Find("LeftArm"), childLeftArmSprites);
        }
        else
        {
            if (parent.GetComponent<Character>().gender == Gender.Male)
            {
                SetRandomSprite(parent.Find("Head"), oldMaleHeadSprites);
                SetRandomSprite(parent.Find("Hair"), maleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), maleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), maleLegSprites);
                SetRandomSprite(parent.Find("RightArm"), maleRightArmSprites);
                SetRandomSprite(parent.Find("LeftArm"), maleLeftArmSprites);
            }
            else
            {
                SetRandomSprite(parent.Find("Head"), oldFemaleHeadSprites);
                SetRandomSprite(parent.Find("Hair"), femaleHairSprites);
                SetRandomSprite(parent.Find("Shirt"), femaleShirtSprites);
                SetRandomSprite(parent.Find("Legs"), femaleLegSprites);
                SetRandomSprite(parent.Find("RightArm"), femaleRightArmSprites);
                SetRandomSprite(parent.Find("LeftArm"), femaleLeftArmSprites);
            }
        }
    }


    public Sprite SetRandomSprite(Transform objectToAssignSprite, List<Sprite> spriteList)
    {
        Sprite spriteAssigned = spriteList[Random.Range(0, spriteList.Count)];
        objectToAssignSprite.GetComponent<SpriteRenderer>().sprite = spriteAssigned;
        return spriteAssigned;
    }

    public void SetSprite(Transform objectToAssignSprite, Sprite spriteToAssign)
    {
        if(spriteToAssign != null)
            objectToAssignSprite.GetComponent<SpriteRenderer>().sprite = spriteToAssign;
    }
}
