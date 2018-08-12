using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BodyPart { Head, Hair, LeftArm, RightArm, Body, Legs }
public class SpriteManager : MonoBehaviour
{
    public List<Sprite> headSprites, eyeSprites, noseSprites, eyeBrowSprites, mouthSprites, hairSprites, handSprites, legSprites, armSprites, shoeSprites, beltSprites;
    [Header("Gender Features")]
    public List<Sprite> malePortraitSprites;
    public List<Sprite> femalePortraitSprites;
    public List<Sprite> maleShirtSprites, femaleShirtSprites;
    public List<Sprite> maleHairSprites, femaleHairSprites;
    [Header("Specific Outfits")]
    // cabeza, cabello, brazo izq, brazo derecho, torso, piernas (el par)
    public List<Sprite> medicSprites;
    public void FillCharacterChildSprites(Character character)
    {
        switch (character.job)
        {
            case Job.Medic:
                FillSpecificSprites(character.transform, medicSprites);
                break;
            default:
                FillRandomSprites(character.transform);
                break;
        }
    }

    private void FillSpecificSprites(Transform parent, List<Sprite> specificClothesList)
    {
        FillRandomSprites(parent);
        //SetRandomSprite(parent.Find("Head"), headSprites);
        //SetRandomSprite(parent.Find("Hair"), hairSprites);
        SetSprite(parent.Find("LeftArm"), specificClothesList[2]);
        SetSprite(parent.Find("RightArm"), specificClothesList[3]);
        SetSprite(parent.Find("Shirt"), specificClothesList[4]);
        SetSprite(parent.Find("Legs"), specificClothesList[5]);
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
        SetRandomSprite(parent.Find("Head"), headSprites);
        if (parent.GetComponent<Character>().gender == Gender.Male)
        {
            SetRandomSprite(parent.Find("Hair"), maleHairSprites);
            SetRandomSprite(parent.Find("Shirt"), maleShirtSprites);
        }
        else
        {
            SetRandomSprite(parent.Find("Hair"), femaleHairSprites);
            SetRandomSprite(parent.Find("Shirt"), femaleShirtSprites);
        }
        SetRandomSprite(parent.Find("Belt"), beltSprites);
        //Side searches
        Sprite mirrorSprite = SetRandomSprite(parent.Find("RightLeg"), legSprites);
        SetSprite(parent.Find("LeftLeg"), mirrorSprite);
        mirrorSprite = SetRandomSprite(parent.Find("RightArm"), armSprites);
        SetSprite(parent.Find("LeftArm"), mirrorSprite);
        mirrorSprite = SetRandomSprite(parent.Find("RightHand"), handSprites);
        SetSprite(parent.Find("LeftHand"), mirrorSprite);
        mirrorSprite = SetRandomSprite(parent.Find("RightShoe"), shoeSprites);
        SetSprite(parent.Find("LeftShoe"), mirrorSprite);
        mirrorSprite = SetRandomSprite(parent.Find("RightEye"), eyeSprites);
        SetSprite(parent.Find("LeftEye"), mirrorSprite);
    }


    public Sprite SetRandomSprite(Transform objectToAssignSprite, List<Sprite> spriteList)
    {
        Sprite spriteAssigned = spriteList[Random.Range(0, spriteList.Count)];
        objectToAssignSprite.GetComponent<SpriteRenderer>().sprite = spriteAssigned;
        return spriteAssigned;
    }

    public void SetSprite(Transform objectToAssignSprite, Sprite spriteToAssign)
    {
        objectToAssignSprite.GetComponent<SpriteRenderer>().sprite = spriteToAssign;
    }
}
