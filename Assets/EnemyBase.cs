using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyBase : MonoBehaviour
{
    public enum WEAPONTYPE {
        MELEE,
        REVOLVER
    }
    public int Health;
    public string name;
    public Transform [] points;
    public int currentPoint;
    public float speed = 0.20f;
    public float WayPointRadius = 0.15f;
    
    // WEAPON
    public WeaponObject weaponObject;
    // visibility

    public float VisibilityRadius = 10f;
    public float AttackRadius = 5f;
    private GameObject Robot;
    private GameObject Player;

    // attack
    private float lastAttacked;
    private float fireRate = 0.1f;
    

    void Start(){
        Robot = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().RobotObject.GetComponent<RobotController>().RobotColliderObject;
        Player = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().PlayerObject.GetComponent<CharacterController>().PlayerColliderObject;

    }
    void FixedUpdate(){
        JudgeWayPoint();

        if(IsEnemyFound()){
            if(IsEnemyInAttackArea()){
                Attack();
            }else{
                Move(getMovementDirection(GetEnemyDirection().x));
            }
            
        }else{
         Move(getMovementDirection(points[currentPoint].position.x));
        }
    }

    void Attack(){
        if(Time.time > lastAttacked+fireRate){
            // attack
            lastAttacked = Time.time;
            weaponObject.weapon.FireForEnemy();
            

        }
    }
    int getMovementDirection(float Px){
        if(Px - transform.position.x >=0){
            return 1;
        }else{
            return -1;
        }
    }

    void toggleWayPoint(){
        if(currentPoint == 0){
                currentPoint = 1;
            }else{
                currentPoint = 0;
        }
    }
    void JudgeWayPoint(){
        if(Vector2.Distance(transform.position, points[currentPoint].position)<WayPointRadius){
            toggleWayPoint();
        }
    }
    public Vector2 GetEnemyDirection(){
        float RobotDistance = Vector2.Distance(transform.position, Robot.transform.position);
        float PlayerDistance = Vector2.Distance(transform.position, Player.transform.position);

        if(PlayerDistance < VisibilityRadius){
            
            if(RobotDistance <VisibilityRadius){
                if (RobotDistance < PlayerDistance){
                    return Robot.transform.position;
                }else{
                    return Player.transform.position;
                }
            }
            return Player.transform.position;
            
        }
        return new Vector2(0f,0f);
    }
    public bool IsEnemyFound(){
  
        float RobotDistance = Vector2.Distance(transform.position, Robot.transform.position);
        float PlayerDistance = Vector2.Distance(transform.position, Player.transform.position);

        if(PlayerDistance < VisibilityRadius || RobotDistance < VisibilityRadius){
            return true;
        }
        return false;
    }
    public bool IsEnemyInAttackArea(){
        
        float RobotDistance = Vector2.Distance(transform.position, Robot.transform.position);
        float PlayerDistance = Vector2.Distance(transform.position, Player.transform.position);

        if(PlayerDistance < AttackRadius || RobotDistance < AttackRadius){
            return true;
        }
        return false;
    }
    public void Move(int direction){
        Vector2 newPosition = transform.position;
        newPosition.x +=direction*speed;
        transform.position=newPosition;

        if (direction == 1){
            if (transform.rotation.eulerAngles.y != 0f){
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }else{
            if (transform.rotation.eulerAngles.y != 180f){
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

            }

        }
    }

    public void takeDamage(int damage){
        
        if (Health-damage <=0){
            Debug.Log("I am dead dawg");
            Destroy(gameObject);
        }
        Health-= damage;
    }
}
