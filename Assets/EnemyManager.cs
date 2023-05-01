using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class EnemyManager : MonoBehaviour
{
    public Group [] groups;
    public float ActivationRadius;
    private GameObject Player;
    private GameObject Robot;

    void Start(){
        Robot = GameObject.FindGameObjectWithTag("RobotWrapper");
        Player = GameObject.FindGameObjectWithTag("PlayerWrapper");
        
    }

    void FixedUpdate(){
        Vector2 robotPosition = Robot.GetComponent<RobotController>().RobotColliderObject.transform.position;
        Vector2 playerPosition = Player.GetComponent<CharacterController>().PlayerColliderObject.transform.position;
        for(int i = 0; i < groups.Length; i++){
            if(Vector2.Distance(robotPosition, groups[i].transform.position) < ActivationRadius || Vector2.Distance(playerPosition, groups[i].transform.position) < ActivationRadius){
                if(!groups[i].hasSpawned){
                groups[i].SpawnGroup();
                }

            }
        }
    }    
}
