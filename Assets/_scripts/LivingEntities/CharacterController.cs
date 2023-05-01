using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject PlayerColliderObject;
 
    public float speed = 0.25f;


    public void Move(int direction){

        Vector2 newPosition = PlayerColliderObject.gameObject.transform.position;
        newPosition.x +=direction*speed;
        PlayerColliderObject.gameObject.transform.position=newPosition;

        if (direction == 1){
            if (PlayerColliderObject.gameObject.transform.rotation.eulerAngles.y != 0f){
            PlayerColliderObject.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);

            }
        }else{
            if (PlayerColliderObject.gameObject.transform.rotation.eulerAngles.y != 180f){
            PlayerColliderObject.gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);

            }

        }
    }

 
    
    public void Jump(){
        bool isGrounded = PlayerColliderObject.GetComponent<MainPlayerCollider>().isGrounded;
        PlayerColliderObject.GetComponent<MainPlayerCollider>().Jump();
        

    }
}
