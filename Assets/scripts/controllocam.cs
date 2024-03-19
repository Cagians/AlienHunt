using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllocam : MonoBehaviour
{
    public Transform cam;
    public Transform centro;
    public Transform camerapref;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        cam.position = camerapref.position;
        if (Physics.Raycast(centro.position, cam.TransformDirection(-Vector3.forward),out hit,5))
        
            if(hit.collider != null){
                cam.position = hit.point+cam.TransformDirection(Vector3.forward)*2.5f;
            }
         Debug.DrawRay(centro.position, cam.TransformDirection(-Vector3.forward)*5, Color.red);
    }
}
