using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerScript Player; 
    public PlayerScript Robot; 
    public GameObject PlayerObject;
    public GameObject RobotObject;
    public GameObject InputManagement;

    private GameObject PlayerMainObj;
    private GameObject RobotMainObj;
    public CameraManager  camManager;
    public HUDManager hudManager;

    public bool RobotOnly;
    // Start is called before the first frame update
    public bool IsPlayer;
    
    void Start(){
        PlayerMainObj = PlayerObject.GetComponent<CharacterController>().PlayerColliderObject;
        RobotMainObj = RobotObject.GetComponent<RobotController>().RobotColliderObject;
        InputManagement.GetComponent<InputManager>().enabled = true;
        InputManagement.GetComponent<RobotInputManager>().enabled = false;
        RobotObject.GetComponent<RobotController>().IsInControl = false;
        camManager.UpdateCam(PlayerMainObj.transform);
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();
    }
    public void toggleController(){
        if(RobotOnly){
            if(IsPlayer){
                InputManagement.GetComponent<InputManager>().enabled = false;
                InputManagement.GetComponent<RobotInputManager>().enabled = true;
                IsPlayer= false;
                RobotObject.GetComponent<RobotController>().IsInControl = true;
                camManager.UpdateCam(RobotMainObj.transform);
                hudManager.EnableRobot();
                hudManager.SetAmmo(RobotObject.GetComponent<RobotController>().ammo);
            }
            return;
        }
        if (IsPlayer){
            InputManagement.GetComponent<InputManager>().enabled = false;
            InputManagement.GetComponent<RobotInputManager>().enabled = true;
            IsPlayer= false;
            RobotObject.GetComponent<RobotController>().IsInControl = true;
            camManager.UpdateCam(RobotMainObj.transform);
            hudManager.EnableRobot();
            hudManager.SetAmmo(RobotObject.GetComponent<RobotController>().ammo);
        }else{
            InputManagement.GetComponent<InputManager>().enabled = true;
            InputManagement.GetComponent<RobotInputManager>().enabled = false;
            RobotObject.GetComponent<RobotController>().IsInControl = false;
            IsPlayer= true;
            camManager.UpdateCam(PlayerMainObj.transform);
            hudManager.EnablePlayer();
        }
    }
}
