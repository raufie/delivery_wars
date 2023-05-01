using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public PlayerManager playerManager;
    public Transform Goal;

    public Vector2 StartPosition;
    public Vector2 TargetPosition;
    
    private float T;
    public float speed=5f;
    private bool HasLaunchBegun;
    private bool HasReachedGoal;
    private float THRUST_TIME = 5f;
    private float STARTED_BURN_AT;

    private bool IS_INDEPENDENT;
    private CameraManager camManager;
    public void FireUp(){
        Debug.Log("FIRING UP");
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        playerManager.RobotOnly = true;
        // lock controls
        playerManager.RobotObject.GetComponent<RobotController>().locked = true;
        // make robot child of rocket
        playerManager.RobotObject.transform.SetParent(transform);
        //  reach the point
        // 

        StartPosition = transform.position;
        TargetPosition = Goal.position;
        T = 0;
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
        HasLaunchBegun = true;
        camManager.UpdateCam(transform);
        camManager.ZoomOut();
    }

    float f(float t){
        float x = T*t - 1;
        float exp = (Mathf.Exp(x) - Mathf.Exp(-x)) / (Mathf.Exp(x) + Mathf.Exp(-x));

        return (exp+1)/2;
    }
    void FixedUpdate(){
        // reach target
        
        if(HasLaunchBegun && !HasReachedGoal){
            float t = f(T);
            transform.position = new Vector2(transform.position.x, transform.position.y+speed*t);

            // Increment the elapsed time
            T += Time.deltaTime;
            if(Vector2.Distance(transform.position, Goal.position) < 10f){
                HasReachedGoal = true;
                STARTED_BURN_AT = Time.time;
                Debug.Log("Reached deploy point");
                camManager.ResetZoom();
                playerManager.RobotObject.transform.SetParent(transform);
                camManager.UpdateCam(transform);
            }
        }
        if(HasReachedGoal && !IS_INDEPENDENT){
            // add some thrust
            
            if(Time.time < STARTED_BURN_AT + THRUST_TIME ){

                playerManager.RobotObject.GetComponent<RobotController>().RobotColliderObject.GetComponent<RobotCollider>().Thrust();
            }else{
                // release
        
                playerManager.RobotObject.GetComponent<RobotController>().RobotColliderObject.GetComponent<RobotCollider>().GetComponent<Rigidbody2D>().gravityScale = 0f;
                playerManager.RobotObject.GetComponent<RobotController>().locked = false;

                IS_INDEPENDENT = true;
                camManager.UpdateCam(playerManager.RobotObject.GetComponent<RobotController>().RobotColliderObject.transform);
                
            }


        }
        

    }
    void Detach(){

    }
// go from a to b in a smooth way so it looks cool
    
}
