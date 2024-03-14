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
    private Transform _cube;


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
/*
        // vettori per la camera e per puntare gli oggetti non ci ho capito una secchia quello che ho scritto funziona basta dilli che quando vede la sfera si trasforma
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            if (hitInfo.collider = 0)
            {

            }
        }
*/
    }
}
