using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ReleaseObjectTelemetry : MonoBehaviour
{

    public enum Opposer {
        PLAYER,
        ENEMY
    }

    public Opposer theOpposer;
    [Header("this projectile prefab may be diffferent for each weapon, may even be null like in melee")]
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed;
    public GameObject Firey;

    Dictionary<Opposer, string > OpposerTag = new Dictionary<Opposer, string>() {
        {Opposer.PLAYER, "Player"},
        {Opposer.ENEMY, "enemy"},
    }; 

    private List<int> instanceIDs = new List<int>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == OpposerTag[theOpposer]){
            instanceIDs.Add(collision.gameObject.GetInstanceID());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == OpposerTag[theOpposer]){
            instanceIDs.Remove(collision.gameObject.GetInstanceID());
        }
    }
    public GameObject[] GetAttackableObjects(){
        
        List<GameObject> gameObjects = new List<GameObject>();
        
        GameObject[] allGameObjects = Object.FindObjectsOfType<GameObject>();

   
        gameObjects = allGameObjects.Where(obj => instanceIDs.Contains(obj.GetInstanceID())).ToList();

        return gameObjects.ToArray();
   
    }
    public string getOpposerKey(){
        return OpposerTag[theOpposer];
    }
    
    public GameObject LaunchObject(){
        return Instantiate(ProjectilePrefab, transform.position,Firey.GetComponent<CharacterController>().PlayerColliderObject.transform.rotation);
    }
    public GameObject LaunchObjectForEnemy(){
        return Instantiate(ProjectilePrefab, transform.position,Firey.transform.rotation);
    }
}
