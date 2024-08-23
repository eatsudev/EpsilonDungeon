using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string requiredItemTag; 
    private GameObject droppedItem; 

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            droppedItem = eventData.pointerDrag;
            droppedItem.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public bool CheckItem()
    {
        if (droppedItem != null && droppedItem.CompareTag(requiredItemTag))
        {
            Debug.Log("Correct item");
            return true; 
        }
        else
        {
            Debug.Log("Incorrect item");
            ResetItem(); 
            return false;
        }
    }

    public void ResetItem()
    {
        if (droppedItem != null)
        {
            droppedItem.GetComponent<DragDrop>().ResetPosition();
            droppedItem = null;
        }
    }

}
