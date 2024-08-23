using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDragDrop : MonoBehaviour
{
    public GameObject canvasDragDrop;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            canvasDragDrop.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    

}
