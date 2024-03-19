using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public Transform direzione;
    public int speed = 30;
    public float jumpForce=15f; //potenza del salto
    private Vector3 nextmov;
    public ConstantForce  mov;
    public LayerMask terreno;   //Layer del terreno
    bool isGrounded=true;    //true= Il player è a terra, false= è in aria

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.velocity = Vector2.down * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Salta pdb");
            
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 0, myRigidBody.velocity.z);//Rimuovo ogni velocita residua, così che ogni salto sia uguale
            myRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//Un metodo forse migliore per fare il salto, non ho messo time.deltaTime, dice che non serve bo 
            /*myRigidBody.velocity = Vector2.up * speed * Time.deltaTime;*/
            isGrounded=false;   //Il player è sicuramente in aria qui
        }
        float vert = Input.GetAxis("Horizontal");
        float oriz = Input.GetAxis("Vertical");
        mov.force = direzione.TransformDirection(new Vector3(vert,0,oriz)*speed*Time.deltaTime);

        
    }
    //Funzione base di unity che verifica le collisioni
    //Se il player collide con il terreno, isGrounded=true
    void OnCollisionEnter(Collision collision)
    {   
        //Qua fa cose bit wise per verificare dov'è il terreno tipo, ma in poche parole verifica la collisione con il layer terreno
        if ((terreno.value & (1 << collision.gameObject.layer)) != 0)
        {   
            isGrounded = true;
            Debug.Log("A terra pdb");
        }
    }
    //Stessa cosa, al momento della fine della collisione, significa che il player è in aria, quindi isGrounded=false
    void OnCollisionExit(Collision collision)
    {
        if ((terreno.value & (1 << collision.gameObject.layer)) != 0)
        {
            isGrounded = false;
            Debug.Log("In aria pdb");
        }
    }
}
