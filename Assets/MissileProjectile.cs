using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    public int Damage;
    public float Radius;
    public float TIMEOUT = 5f;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "enemy"){
            Explode();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(startTime + TIMEOUT <= Time.time){
            Explode();
        }
    }
    void Explode(){
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("explosion");
        Vector2 position = transform.position;
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, Radius);
        foreach (Collider2D hit in hits)
        {
            if(hit.tag == "enemy"){
                hit.gameObject.GetComponent<EnemyBase>().takeDamage(Damage);
            }
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            
        }

        
        Destroy(gameObject);
    }
    public void StartFire(Vector2 Direction){
        startTime = Time.time;
        GetComponent<Rigidbody2D>().AddForce(Direction);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
