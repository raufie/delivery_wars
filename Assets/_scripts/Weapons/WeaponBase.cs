using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase {
    // Start is called before the first frame update
    // as all weapons have limitless ammo except the grenade-ish surprize crate... lets generalize for tht
    // fire
    // isFireable

    
    protected float FireRate;
    public string Name;
    public GameObject releaseObject;
    protected int damagePoints;
    protected float lastFiredTime = 0f;
    protected int maxAmmo;
    public int ammo;
    public float AttackDistance;
    // constructor
    public WeaponBase (string name, float fireRate, int damagePoints, int maxAmmo, int ammo, GameObject releaseObject, float AttackDistance){
        this.Name = name;
        this.FireRate = fireRate;
        this.damagePoints = damagePoints;
        this.maxAmmo = maxAmmo;
        this.ammo = ammo;
        this.releaseObject = releaseObject; 
        this.AttackDistance = AttackDistance;
    }
    public void AddAmmo(int ammo){
        if (ammo+this.ammo > maxAmmo){
            this.ammo = maxAmmo;
        }else {
            this.ammo += ammo;
        }
    }
    public virtual void Fire(bool limitlessAmmo = true){
        if (IsFireable()){
            lastFiredTime = Time.time;
            if (!limitlessAmmo){
                ammo-=1;
            }
        }
    }
    public virtual void FireForEnemy(bool limitlessAmmo = true){
        if (IsFireable()){
            lastFiredTime = Time.time;
            if (!limitlessAmmo){
                ammo-=1;
            }
        }
    }
    public bool IsFireable(){
        if (ammo > 0  && Time.time > lastFiredTime+FireRate){
            return true;
        }else {
            return false;
        }
    }
    public GameObject [] CastRay(){
        string key = releaseObject.GetComponent<ReleaseObjectTelemetry>().getOpposerKey();

        Vector2 direction = releaseObject.transform.right;
        Ray ray = new Ray(releaseObject.transform.position, direction);

            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistance);

            List<GameObject> hitObjects = new List<GameObject>();
            foreach (RaycastHit2D hit in hits)
            {
                if(hit.collider.tag == key){
                    hitObjects.Add(hit.collider.gameObject);
                }
            }
            return hitObjects.ToArray();

    }
    public GameObject [] CastRayForEnemy(){
        

        Vector2 direction = releaseObject.transform.right;
        Ray ray = new Ray(releaseObject.transform.position, direction);

            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, AttackDistance);

            List<GameObject> hitObjects = new List<GameObject>();
            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.tag);
                if(hit.collider.tag == "Player" || hit.collider.tag == "robot"){
                    hitObjects.Add(hit.collider.gameObject);
                    
                }
            }
            return hitObjects.ToArray();

    }
}
