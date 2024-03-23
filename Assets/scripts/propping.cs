using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propping : MonoBehaviour
{
    public Transform playerMesh;
    public Transform camera;
    public KeyCode trasformationKey = KeyCode.E;
    public KeyCode originalFormKey = KeyCode.Q;
    public float interactionRange = 50f;
    int layerMask=1<<6;
    public Transform camerapref;
    public Transform sphereTransform;
    public Transform pTransform;
    public Transform cameramov;
    private Mesh originalMesh;
    private Material[] originalMaterial;
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~layerMask;
        
        MeshFilter originalMeshFilter = playerMesh.GetComponent<MeshFilter>();
        originalMaterial = playerMesh.GetComponent<Renderer>().materials;
        originalScale = playerMesh.localScale;

        originalMesh = originalMeshFilter.mesh;
    }

    // Update is called once per frame
    void Update()
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
                pTransform=playerMesh.GetComponent<Transform>();
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
                    pTransform.rotation = Quaternion.LookRotation(camera.forward, Vector3.up);

                    cameramov.position = camerapref.position + camera.TransformDirection(-Vector3.forward)*0.05f*transform.localScale.y;
                }
            }
        }

        if (Input.GetKeyDown(originalFormKey))
        {
            playerMesh.GetComponent<MeshFilter>().mesh = originalMesh;
            playerMesh.GetComponent<Renderer>().materials = originalMaterial;
            playerMesh.localScale = originalScale;
        }
    }
}
