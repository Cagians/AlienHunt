using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public int speed = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = Vector2.down * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            myRigidBody.velocity = Vector2.up * speed * Time.deltaTime;
        } if(Input.GetKeyDown(KeyCode.W) == true)
        {
            myRigidBody.velocity = Vector3.forward * speed * Time.deltaTime;
        } if(Input.GetKeyDown(KeyCode.A) == true)
        {
            myRigidBody.velocity = Vector3.left * speed * Time.deltaTime;
        } if(Input.GetKeyDown(KeyCode.S) == true)
        {
            myRigidBody.velocity = Vector3.back * speed * Time.deltaTime;
        } if(Input.GetKeyDown(KeyCode.D) == true)
        {
            myRigidBody.velocity = Vector3.right * speed * Time.deltaTime;
        }

    }
}
