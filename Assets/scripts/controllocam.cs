using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllocam : MonoBehaviour
{
    public Transform cam;
    public Transform centro;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(centro.position, cam.TransformDirection(-Vector3.forward),out hit,5))
            if(hit.collider != null)
                cam.position = hit.point+cam.TransformDirection(Vector3.forward);
         Debug.DrawRay(centro.position, cam.TransformDirection(-Vector3.forward)*5, Color.red);
    }
}
