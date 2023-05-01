using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InteractableObserver : MonoBehaviour
{

    public enum Type {
        DOOR, 
        ROCKETINTERACTION
    }

    public Type ActionType;
    public GameObject UseTextObject;
    public GameObject Player;
    public GameObject Robot;
    public InteractableBase Interactable;
    public GameObject SubjectGameObject;


    public float activationDistance;
    private bool CanToggleText;
    // Start is called before the first frame update
    void Start()
    {
        Robot = GameObject.FindGameObjectWithTag("RobotWrapper");
        Player = GameObject.FindGameObjectWithTag("PlayerWrapper");
        if (ActionType == Type.DOOR){
        Interactable = new InteractableDoor(SubjectGameObject);
        }else if(ActionType == Type.ROCKETINTERACTION){
            Interactable = new InteractableRocket(SubjectGameObject);
        }
    }

    public void Interact(int signal=1){
        Interactable.PerformAction(signal);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 robotPosition = Robot.GetComponent<RobotController>().RobotColliderObject.transform.position;
        float distance = Vector2.Distance(transform.position, robotPosition);
        if (distance <= activationDistance){
            UseTextObject.SetActive(true);
            CanToggleText = true;
             if (Input.GetKeyDown(KeyCode.E))
                {
                    // Do something when the space button is pressed
                    Interact(1);
                }
        }else{
            if(CanToggleText){
            UseTextObject.SetActive(false);
            CanToggleText = false;
            }
        }
    }
}
