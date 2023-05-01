using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverWeapon: WeaponBase {
    public RevolverWeapon (string name, float fireRate, int damagePoints, int maxAmmo, int ammo, GameObject releaseObject, float AttackDistance):
     base (name, fireRate, damagePoints, maxAmmo, ammo, releaseObject, AttackDistance) {
    }

    public override void Fire(bool limitlessAmmo = false){

        if (IsFireable()){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("revolver");
            // MULTI CAST ONLY
            // get prefab
            
            base.Fire();
            
            GameObject obj = releaseObject.GetComponent<ReleaseObjectTelemetry>().LaunchObject();
            float angleX = releaseObject.GetComponent<ReleaseObjectTelemetry>().Firey.GetComponent<CharacterController>().PlayerColliderObject.transform.rotation.eulerAngles.y;
            float dir = 1.0f;
            if (angleX == -180f || angleX == 180f){
                dir = -1.0f;
            }
            obj.GetComponent<RevolverProjectileScript>().StartObject(damagePoints, releaseObject.GetComponent<ReleaseObjectTelemetry>().ProjectileSpeed*dir);

            
        }
    }

    public override void FireForEnemy(bool limitlessAmmo = true){
        
        if (IsFireable()){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("revolver");
            // MULTI CAST ONLY
            GameObject [] gameObjects = CastRayForEnemy();
            
            base.Fire();

            GameObject obj = releaseObject.GetComponent<ReleaseObjectTelemetry>().LaunchObjectForEnemy();
            obj.GetComponent<RevolverProjectileScript>().IsForEnemy = true;
            float angleX = releaseObject.GetComponent<ReleaseObjectTelemetry>().Firey.transform.rotation.eulerAngles.y;
            float dir = 1.0f;
            if (angleX == -180f || angleX == 180f){
                dir = -1.0f;
            }
            obj.GetComponent<RevolverProjectileScript>().StartObject(damagePoints, releaseObject.GetComponent<ReleaseObjectTelemetry>().ProjectileSpeed*dir);

        }
    }
}