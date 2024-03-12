using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public Transform direzione;
    public int speed = 30;
    private Vector3 nextmov;
    public ConstantForce  mov;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = Vector2.down * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * speed * Time.deltaTime;
        }
        float vert = Input.GetAxis("Horizontal");
        float oriz = Input.GetAxis("Vertical");
        mov.force = direzione.TransformDirection(new Vector3(vert,0,oriz)*speed*Time.deltaTime);

        
    }
}
