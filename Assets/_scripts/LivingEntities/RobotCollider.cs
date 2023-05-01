using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCollider : MonoBehaviour
{
    public bool isGrounded;
    public float Vi = 2f;
    public float G = 5f;
    public float height_param = 3f;
    private bool isJumping;
    private float jumpStartTime;
    private float preJumpHeight;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground"){
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground"){
            isGrounded = false;
        }
    }
    
    
    void FixedUpdate(){
        if (isJumping){
          
        }
    }
    public void Thrust(){
        

        GetComponent<Rigidbody2D>().AddForce(transform.up*24f);
    }

    public void Rotate(int direction){
        transform.Rotate(0f, 0f, ((float)direction)*2f);
    }
}
