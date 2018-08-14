using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypewriterEffect : MonoBehaviour {
    public string textString="";
    public string fullText= "";
    public float textSpeed = 0.1f;
    public int currentChar = 0;
    public Text writerText;
    public GameObject holder; 

	// Use this for initialization
	void Awake () {
        writerText = GetComponent<Text>();
        fullText = writerText.text;
        writerText.text = "";
        StartCoroutine(TypeWriterRoutine());
	}
    

    public IEnumerator TypeWriterRoutine()
    {
        while (!writerText.text.Equals(fullText))
        {
            writerText.text  += fullText[currentChar].ToString();
            if (fullText[currentChar]!='.')
            {
                yield return new WaitForSeconds(textSpeed);
            }
            else
            {
                yield return new WaitForSeconds(1.0f);
            }
            currentChar++;
        }
        holder.SetActive(false);
    }


	
}
