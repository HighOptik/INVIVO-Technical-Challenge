using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFocusControl : MonoBehaviour
{
    public static CamFocusControl instance;
    public bool moveTo;
    public Transform target;
    public List<Transform> targets;
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
    public void NewFocusPos(Transform pos)
    {
        target = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target.position, Time.deltaTime);

            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, target.rotation, Time.deltaTime);
        }
    }
}
