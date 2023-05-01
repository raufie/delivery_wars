using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public GameObject RobotColliderObject;
    public GameObject MissilePrefab;
    public GameObject releaseObject;
    public float speed = 0.25f;
    public float missileForce = 10f;
    public int damage = 80;
    public float radius = 6f;

    // AMMO MANAGEMENT
    public int MaxAmmo;
    public int ammo;
    public bool IsInControl;
    public float FollowRadius = 10f;
    public bool locked;
    public HUDManager hudManager;

    public ParticleSystem particles;
    public float particlesForce = 10f;
    void Start(){
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();
    }
    public void FixedUpdate(){
        bool isGrounded = RobotColliderObject.GetComponent<RobotCollider>().isGrounded;
        if(!IsInControl && isGrounded){
            FollowPlayer();
        }

    }
     int getMovementDirection(float Px){
        if(Px - RobotColliderObject.transform.position.x >=0){
            return 1;
        }else{
            return -1;
        }
    }
    void FollowPlayer(){
        Vector2 p = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(Vector2.Distance(RobotColliderObject.transform.position, p) > FollowRadius){
            Move(getMovementDirection(p.x));
        }
    }
    public void Move(int direction){
        if (locked){
            return;
        }
        if(!RobotColliderObject.GetComponent<RobotCollider>().isGrounded){
            if (RobotColliderObject.gameObject.transform.rotation.eulerAngles.y != 0f){
                RobotColliderObject.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            RobotColliderObject.GetComponent<RobotCollider>().Rotate(direction);
            return;
        }
        Vector2 newPosition = RobotColliderObject.gameObject.transform.position;
        newPosition.x +=direction*speed;
        RobotColliderObject.gameObject.transform.position=newPosition;

        if (direction == 1){
            if (RobotColliderObject.gameObject.transform.rotation.eulerAngles.y != 0f){
            RobotColliderObject.gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);

            }
        }else{
            if (RobotColliderObject.gameObject.transform.rotation.eulerAngles.y != 180f){
            RobotColliderObject.gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);

            }

        }
    }

 
    
    public void Thrust(){
        if (locked){
            return;
        }
        particles.Emit(10);
        bool isGrounded = RobotColliderObject.GetComponent<RobotCollider>().isGrounded;
        RobotColliderObject.GetComponent<RobotCollider>().Thrust();
    }

    public void Fire(){
        if (locked){
            return;
        }
        if(ammo > 0){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("missile");
            GameObject obj = Instantiate(MissilePrefab, releaseObject.transform.position, releaseObject.transform.rotation);
            obj.GetComponent<MissileProjectile>().Damage = damage;
            obj.GetComponent<MissileProjectile>().Radius= radius;
            obj.GetComponent<MissileProjectile>().StartFire(releaseObject.transform.right*missileForce);
            ammo--;
        }
        hudManager.SetAmmo(ammo);
    }
    public void AddAmmo(int ammo){
        if( ammo + this.ammo > MaxAmmo){
            this.ammo = MaxAmmo;
        }else{
            this.ammo+= ammo;
        }
        hudManager.SetAmmo(ammo);
    }
}
