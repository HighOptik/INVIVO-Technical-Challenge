using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable_Cam : MonoBehaviour
{
    public Transform camPos;
    private void OnMouseDown()
    {
        Debug.Log("saasda");
        if (EventSystem.current.IsPointerOverGameObject()) return;
    }
}
