using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TapEvents : MonoBehaviour
{
    [UnityEngine.Serialization.FormerlySerializedAs("leftPanel")]
    public PanelInfo[] panels;
    public Text responseText;
    public Text scoreText;
    int score = 0;
    public int Score { get { return score; }
            set {
            score = value;
            scoreText.text = score.ToString();
        } }
    public Character[] frontCharacters = new Character[2];


    public void Start()
    {
        Score = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
            if (hitInfo)
            {
                //character = hitInfo.transform.gameObject.GetComponent<TappableCharacter>();
                //if (character != null)
                //{
                //DisplayInfo(character);
                //}
            }
        }
    }

    public void DisplayInfo(Character character)
    {
        panels[(int)character.side].FillPanel(character);
    }

    public void PassCharacter(int side)
    {
        frontCharacters[side].Pass();
        FindObjectOfType<CrowdLines>().ProceedLine(side);
    }
    public void BlockCharacter(int side)
    {
        frontCharacters[side].Block();
        FindObjectOfType<CrowdLines>().ProceedLine(side);
    }
    public void KillCharacter(int side)
    {
        frontCharacters[side].Kill();
        FindObjectOfType<CrowdLines>().ProceedLine(side);
    }
    public void AskName(int side)
    {
        Respond(side, frontCharacters[side].AskName());
    }
    public void AskAge(int side)
    {
        Respond(side, frontCharacters[side].AskAge());
    }
    public void Respond(int side, string response)
    {
        responseText.text = response;
    }
}


[System.Serializable]
public class PanelInfo
{
    public GameObject panel;
    public Text txtAge;
    public Text txtName;
    public Text txtInfected;
    public Text txtJob;
    public Text txtNotes;
    public Image imgPortrait;



    public void FillPanel(Character character)
    {
        txtName.text = "Name: " + character.name;
        txtAge.text = "Age: " + character.age.ToString();
        txtJob.text = character.job.ToString();
        txtNotes.text = "Notes: ";
        if (character.diseases.Count > 0)
        {
            foreach(Disease disease in character.diseases)
            {
                txtNotes.text += "\n " + disease.ToString();
            }
        }
        else
        {
            txtNotes.text += "\nN/A";
        }
        imgPortrait.sprite = character.portrait;
        if (character.infected)
        {
            txtInfected.text = "Infected";
        }
        else
        {
            txtInfected.text = "Not Infected";
        }
        ShowPanel();
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }

}