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
    public Transform camera;
    int layerMask=1<<6;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        layerMask = ~layerMask;
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

        Trasformazione();
    }
    void Trasformazione()
    {
        Ray ray = new Ray(camera.position, camera.forward);
        RaycastHit hit;
        
        Debug.DrawRay(camera.position, camera.forward*interactionRange,Color.green);
        // Se il raycast colpisce un oggetto entro tot range
        if (Physics.Raycast(ray, out hit, interactionRange,layerMask))
        {
            // Controllo se l'oggetto colpito è interagibile e se il tasto viene premuto
            if (hit.collider.CompareTag("Trasformabile") && Input.GetKeyDown(trasformationKey))
            {
                MeshFilter objectMesh = hit.collider.gameObject.GetComponent<MeshFilter>();
                Transform transform=hit.collider.transform;
                MeshCollider pMeshCollider=playerMesh.GetComponent<MeshCollider>();
                Transform pTransform=playerMesh.GetComponent<Transform>();
                MeshFilter playerMeshFilter = playerMesh.GetComponent<MeshFilter>();
                Renderer render=hit.collider.GetComponent<Renderer>();
                // Se entrambi gli oggetti hanno una mesh
                

                if (objectMesh != null && playerMeshFilter != null)
                {
                    playerMeshFilter.mesh = objectMesh.sharedMesh;
                    pMeshCollider.sharedMesh=objectMesh.sharedMesh;
                    List<Material> m=new List<Material>();
                    render.GetMaterials(m);
                    Renderer pRender=playerMesh.GetComponent<Renderer>();
                    pRender.SetMaterials(m);
                    pTransform.localScale=transform.localScale;
                    pTransform.rotation=transform.rotation;
                    
                    camera.position+=camera.TransformDirection(-Vector3.forward)*0.05f*transform.localScale.y;
                    
                }
            }
        }

    }
}
