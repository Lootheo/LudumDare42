using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {
    public List<Sprite> headSprites, eyeSprites,noseSprites,eyeBrowSprites, mouthSprites, hairSprites,handSprites,legSprites,armSprites,shirtSprites,shoeSprites,beltSprites;
	
    public void FillCharacterChildSprites(Transform parent)
    {
        //Central, unique sprites

        SetRandomSprite(parent.Find("Head"),headSprites);
        SetRandomSprite(parent.Find("Head/Hair"), hairSprites);
        SetRandomSprite(parent.Find("Head/Mouth"),  mouthSprites);
        SetRandomSprite(parent.Find("Head/Nose"),  noseSprites);
        SetRandomSprite(parent.Find("Shirt"), shirtSprites);
        SetRandomSprite(parent.Find("Belt"), beltSprites);

        //Side searches
        Transform right = parent.Find("Right");
        Transform left = parent.Find("Left");
        Sprite mirrorSprite =  SetRandomSprite(right.Find("RightLeg"), legSprites);
        SetSprite(left.Find("LeftLeg"), mirrorSprite);
        mirrorSprite = SetRandomSprite(right.Find("RightArm"), armSprites);
        SetSprite(left.Find("LeftArm"), mirrorSprite);
        mirrorSprite = SetRandomSprite(right.Find("RightHand"), handSprites);
        SetSprite(left.Find("LeftHand"), mirrorSprite);
        mirrorSprite = SetRandomSprite(right.Find("RightShoe"), shoeSprites);
        SetSprite(left.Find("LeftShoe"), mirrorSprite);
        mirrorSprite = SetRandomSprite(right.Find("RightEye"), eyeSprites);
        SetSprite(left.Find("LeftEye"), mirrorSprite);




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
