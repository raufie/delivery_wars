using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprizeProjectileScript : MonoBehaviour
{
    private bool hasInitialized;
    private float speed;
    private float direction;
    public float TIMEOUT = 2f;
    private float timeLaunched;
    // 

    public float Vi = 2f;
    public float G = 5f;
    public float height_param = 3f;
    private float preJumpHeight;
    private bool isJumping;
    private float jumpStartTime;
    public float Vx = 0.2f;
    // Start is called before the first frame update
    public float radius = 1f;
    public float force = 100f;
    private int damage = 20;
    void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground"){
            isJumping = false;
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJumping){
            float t = Time.time - jumpStartTime;
            float height = calculateJumpHeight(t);

            transform.position = new Vector2(transform.position.x+Vx, preJumpHeight+height);
            
        }
        if(hasInitialized){
            if((timeLaunched + TIMEOUT) <= Time.time){
                Explode();
            }
        }
       
    }
    public void StartObject(int damage, float speed){
        timeLaunched = Time.time;
        hasInitialized = true;
        this.damage = damage;
        this.Vx = speed;
        Jump();
    }
    public void Jump(){
        
        jumpStartTime = Time.time;
        isJumping = true;
        preJumpHeight = transform.position.y;
        
    }
    float calculateJumpHeight(float t){

        return height_param*(Vi * t - 0.5f*G*t*t);
    }
    void Explode(){
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("explosion");
        Vector2 position = transform.position;
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, radius);
        foreach (Collider2D hit in hits)
        {
            if(hit.tag == "enemy"){
                hit.gameObject.GetComponent<EnemyBase>().takeDamage(damage);
            }
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            
        }


        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
