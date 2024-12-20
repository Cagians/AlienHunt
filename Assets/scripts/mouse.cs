using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public Transform transform;
    public float mouseSensitivity = 1f;
    float xRotation = 0f;

    [SerializeField]
    public KeyCode trasformationKey = KeyCode.E;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        //Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 75f);

        transform.transform.eulerAngles = new Vector3(xRotation, transform.rotation.eulerAngles.y, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
