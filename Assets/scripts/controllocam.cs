using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllocam : MonoBehaviour
{
    public Transform cam;
    public Transform centro;
    public Transform cameramov;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        cam.position = cameramov.position;
        if (Physics.Raycast(centro.position, cam.TransformDirection(-Vector3.forward),out hit,Vector3.Distance(centro.position,cameramov.position)))
        
            if(hit.collider != null){
                cam.position = hit.point+cam.TransformDirection(Vector3.forward)*2.5f;
            }
         Debug.DrawRay(centro.position, cam.TransformDirection(-Vector3.forward)*Vector3.Distance(centro.position,cameramov.position), Color.red);
    }
}
