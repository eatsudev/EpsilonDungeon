using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunningText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Reference to the TextMeshProUGUI component
    public float typingSpeed = 0.05f;    // Speed of the typing effect

    private string fullText;             // The full text to display

    private void Start()
    {
        // Store the full text from the TextMeshProUGUI component
        fullText = textMeshPro.text;

        // Start the typewriter effect
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.text = "";  // Clear the text initially

        for (int i = 0; i < fullText.Length; i++)
        {
            textMeshPro.text += fullText[i];  // Add one character at a time

            // If the player presses the Space key, skip the effect and show the full text
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textMeshPro.text = fullText;
                break;
            }

            yield return new WaitForSeconds(typingSpeed);  // Wait for the next character
        }
    }
}
