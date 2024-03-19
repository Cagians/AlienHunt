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
    public GameObject prop1test;
    public KeyCode trasformationKey = KeyCode.E; 
    public float interactionRange = 50f; // Distanza per interagire con gli oggetti
    public Transform playerMesh;

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

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Se il raycast colpisce un oggetto entro tot range
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // Controllo se l'oggetto colpito è interagibile e se il tasto viene premuto
            if (hit.collider.CompareTag("Trasformabile") && Input.GetKeyDown(trasformationKey))
            {
                // Cambia la mesh dell'oggetto prop1test
                MeshFilter objectMesh = prop1test.GetComponent<MeshFilter>();
                MeshFilter playerMeshFilter = playerMesh.GetComponent<MeshFilter>();

                // Se entrambi gli oggetti hanno una mesh
                if (objectMesh != null && playerMeshFilter != null)
                {
                    //Viene applicata la mesh di prop1test al player
                    playerMeshFilter.mesh = objectMesh.sharedMesh;
                }
            }
        }
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
