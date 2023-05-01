using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverProjectileScript : MonoBehaviour
{
    private bool hasInitialized;
    private float speed;
    private float direction;
    private float TIMEOUT = 2f;
    private float timeLaunched;

    public bool IsForEnemy = false;

    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(IsForEnemy){
// only attacks the player objects
        if (other.tag == "robot" || other.tag == "Player"){
                    other.gameObject.transform.parent.gameObject.GetComponent<PlayerScript>().takeDamage(damage);
                    Destroy(gameObject);
        }
        }else{
            
            if (other.tag == "enemy"){
                other.gameObject.GetComponent<EnemyBase>().takeDamage(damage);
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hasInitialized ){
            transform.position= new Vector2(transform.position.x+speed, transform.position.y);
            if((timeLaunched + TIMEOUT) <= Time.time){
                Destroy(gameObject);
            }
        }
        

        
    }
    public void StartObject(int damage, float speed){
        timeLaunched = Time.time;
        hasInitialized = true;
        this.speed = speed;
        this.damage = damage;
    }

}
