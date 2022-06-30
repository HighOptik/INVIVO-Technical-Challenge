using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Interactable : MonoBehaviour
{
    public Color highlighted;
    Color original;
    public bool launch;
    bool launched;
    Vector3 originalPosition;
    private void OnMouseDown()
    {
        Selected();
        if (EventSystem.current.IsPointerOverGameObject()) return;
    }
    void Start()
    {
        original = GetComponent<MeshRenderer>().material.color;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    public void Selected()
    {
        if (!launch)
        {
            Highlight();
            InterationManager.instance.NewObjectSelected(gameObject);
        }
        else
        {
            Highlight();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void Highlight()
    {
        MeshRenderer[] renders = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in renders)
        {
        meshRenderer.material.color = highlighted;
        }
    }

    private void Update()
    {
        if (launch && !launched)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.GetComponent<Interactable>() && objectHit.GetComponent<Interactable>().launch)
                {
                    // Do something with the object that was hit by the raycast.
                    if (Input.GetMouseButtonDown(0))
                    {
                        Selected();
                        StartCoroutine(Launch(hit.point));
                        InterationManager.instance.NewObjectSelected(objectHit.gameObject);
                    }
                }
            }
        }
        if (launched)
        {
            if (GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                Reset();
            }
        }
    }
    public IEnumerator Launch(Vector3 hitPoint)
    {
        Vector3 direction = (transform.position - hitPoint);
      //  direction.Normalize();
        GetComponent<Rigidbody>().AddForce(direction * 75, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(direction, ForceMode.Impulse);
        yield return new WaitForSeconds(.1f);
        launched = true;
    }

    private void Reset()
    {
        GetComponent<MeshRenderer>().material.color = original;
        launched = false;
        launch = true;
        transform.position = originalPosition;
        transform.eulerAngles = Vector3.zero;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Deselected()
    {
        MeshRenderer[] renders = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in renders)
        {
            meshRenderer.material.color = original;
        }
    }
}
