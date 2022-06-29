using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public CanvasGroup label;
    public Color highlighted;
    Color original;
    private void OnMouseDown()
    {
        Selected();
    }
    void Start()
    {
        label.alpha = 0;
        original = GetComponent<MeshRenderer>().material.color;
        label.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
    }

    // Update is called once per frame
    public void Selected()
    {
        label.alpha = 1;
        GetComponent<MeshRenderer>().material.color = highlighted;
        InterationManager.instance.NewObjectSelected(gameObject);
    }
    public void Deselected()
    {
        label.alpha = 0;
        GetComponent<MeshRenderer>().material.color = original;
    }
}
