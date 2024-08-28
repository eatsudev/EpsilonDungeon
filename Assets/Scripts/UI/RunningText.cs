using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunningText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  
    public float typingSpeed = 0.05f;    

    private string fullText;             

    private void Start()
    {
        fullText = textMeshPro.text;

        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            textMeshPro.text += fullText[i];  

            if (Input.GetKeyDown(KeyCode.Space))
            {
                textMeshPro.text = fullText;
                break;
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
