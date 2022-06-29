using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        void Start()
    {
        
    }

    // Update is called once per frame
    public void NewObjectSelected(GameObject newSelection)
    {
        if (currentlySelected != null)
        {
            currentlySelected.GetComponent<Interactable>().Deselected();
        }

            currentlySelected = newSelection;
         //   currentlySelected.GetComponent<Interactable>().Selected();
    }
}
