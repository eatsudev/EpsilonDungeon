using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public GameObject deathScreen;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
