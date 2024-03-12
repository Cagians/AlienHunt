using System.Security.AccessControl;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copia : MonoBehaviour
{
    public Transform main;
    public Transform child;
    public bool pos;
    public bool rotspec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(pos)
            child.position = main.position;
        if(rotspec){
            child.eulerAngles = new UnityEngine.Vector3(0, main.eulerAngles.y,0);
        }
            
    }
}
