using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dragDropUI;
    public void CloseDragDropUI()
    {
        dragDropUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
