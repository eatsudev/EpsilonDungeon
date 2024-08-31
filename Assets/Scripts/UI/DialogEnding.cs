using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogEnding : MonoBehaviour
{
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject toBeContinued;

    public void CloseDialog1()
    {
        dialog1.SetActive(false);
    }

    public void OpenDialog2()
    {
        dialog2.SetActive(true);
    }

    public void CloseDialog2()
    {
        dialog2.SetActive(false);
    }

    public void OpenDialog3()
    {
        dialog3.SetActive(true);
    }

    public void CloseDialog3()
    {
        dialog3.SetActive(false);
    }

    public void OpenToBeContinued()
    {
        toBeContinued.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
