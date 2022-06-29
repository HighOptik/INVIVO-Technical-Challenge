using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(transform.position - Camera.main.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
/*        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x,mouse.y,transform.position.y));
        Vector3 forward = mouseWorld *//*- transform.position*//*;
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);*/
    }
}
