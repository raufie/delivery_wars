using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerCollider : MonoBehaviour
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
            isJumping = false;
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
            float t = Time.time - jumpStartTime;
            float height = calculateJumpHeight(t);

            transform.position = new Vector2(transform.position.x, preJumpHeight+height);
        }
    }
    public void Jump(){
        if (isGrounded){
            jumpStartTime = Time.time;
            isJumping = true;
            preJumpHeight = transform.position.y;
        }
    }

    float calculateJumpHeight(float t){

        return height_param*(Vi * t - 0.5f*G*t*t);
    }
}
