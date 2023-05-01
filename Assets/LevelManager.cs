using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public int CurrentCheckpoint;
    public int MaxChepoints;

    public Transform Checkpoint1Position;
    public Transform SpacePortPosition;
    public Transform DeliveryPoint;
// all checkpoints are hardcoded here, i dont have the time to make a general (Checkpoint) object 
// to represet custom checkpoint behavior
    public GameObject PlayerObject;
    public GameObject RobotObject;
    public PlayerManager playerManager;
    public float Radius1 = 20f;
    public float PackageRadius = 200f;
    public int finalScene=0;

    private bool allDone = false;

    public Transform RocketTop;

    // hud
    public HUDManager hudManager;

    bool ch1;
    bool ch2;
    bool ch3;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);

        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        
        PlayerObject = playerManager.PlayerObject.GetComponent<CharacterController>().PlayerColliderObject;
        RobotObject = playerManager.RobotObject.GetComponent<RobotController>().RobotColliderObject;
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();

        // 
        
    }
    void FixedUpdate(){
        
        if (allDone){
            hudManager.SetMilestoneText("Package Delivered :)");
        }
        else if(Checkpoint2Condition()){
            Debug.Log("Bruh YOU HAVE DELIVERED THE PACKAGE");
            hudManager.SetMilestoneText("Package Successfully Delivered :)");
            allDone = true;
            SwitchScene();
        }
        else if(Checkpoint1_2Condition()){
            hudManager.SetDistance(Vector2.Distance(RobotObject.transform.position,DeliveryPoint.position));
            hudManager.EnableTelemetry();
            hudManager.SetVelocity(RobotObject.GetComponent<Rigidbody2D>().velocity.x,RobotObject.GetComponent<Rigidbody2D>().velocity.y);
            hudManager.SetMilestoneText("Deliver the package at the location");
        }
        else if(Checkpoint1Condition()){
            hudManager.SetMilestoneText("Reach the top of the rocket");
            Debug.Log("Bruh its done");
        }


    }
    bool Checkpoint1_2Condition(){
        // Reach ROcket Launch
        if (ch2 == true){
                return true;
        }
        if(Vector2.Distance(RobotObject.transform.position, RocketTop.position) < Radius1 ){
            ch2 = true;
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("rocket");
            return true;
        }
        return false;
    } 

    bool Checkpoint1Condition(){
        // Reach ROcket Launch
        if (ch1 == true){
                return true;
        }
        if(Vector2.Distance(PlayerObject.transform.position, SpacePortPosition.position) < Radius1 || Vector2.Distance(RobotObject.transform.position, SpacePortPosition.position)<Radius1){
            ch1 = true;
            return true;
        }
        return false;
    }
    bool Checkpoint2Condition(){
        if (ch3 == true){
                return true;
        }
        // launch and defend rocket
        if(Vector2.Distance(RobotObject.transform.position, DeliveryPoint.position)<PackageRadius){
            ch3 = true;
            return true;
        }
        return false;

        
    }

    public void SwitchScene()
    {
        // Start the coroutine to switch scenes after the delay
        StartCoroutine(SwitchSceneCoroutine());
    }
    private IEnumerator SwitchSceneCoroutine()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(7f);

        // Load the new scene
        SceneManager.LoadScene(finalScene);
    }

}
