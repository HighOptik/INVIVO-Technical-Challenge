using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterationManager : MonoBehaviour
{
    public static InterationManager instance;
    public GameObject currentlySelected;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void NewObjectSelected(GameObject newSelection)
    {
        if (NameLabel.instance)
        {
            NameLabel.instance.UpdateName(newSelection.name);
        }

        if (currentlySelected != null)
        {
            if (currentlySelected != newSelection)
            {
                currentlySelected.GetComponent<Interactable>().Deselected();
                currentlySelected = newSelection;
            }
            else
                return;
        }
        else
        {
            currentlySelected = newSelection;
        }
    }
}