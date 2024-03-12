using Cinemachine;
using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virtualCamera : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera CineMachine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y < Input.mousePosition.y)
        {
            CinemachineVirtualCamera.Destroy(gameObject);
        }
    }
}
