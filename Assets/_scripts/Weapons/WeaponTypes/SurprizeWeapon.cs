using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurprizeWeapon: WeaponBase {
    public SurprizeWeapon (string name, float fireRate, int damagePoints, int maxAmmo, int ammo, GameObject releaseObject, float AttackDistance):
     base (name, fireRate, damagePoints, maxAmmo, ammo, releaseObject, AttackDistance) {
    }

    public override void Fire(bool limitlessAmmo = false){

        if (IsFireable()){
            // MULTI CAST ONLY
            // get prefab
            
            
            base.Fire(false);
            GameObject obj = releaseObject.GetComponent<ReleaseObjectTelemetry>().LaunchObject();
            float angleX = releaseObject.GetComponent<ReleaseObjectTelemetry>().Firey.GetComponent<CharacterController>().PlayerColliderObject.transform.rotation.eulerAngles.y;
            float dir = 1.0f;
            if (angleX == -180f || angleX == 180f){
                dir = -1.0f;
            }
            obj.GetComponent<SurprizeProjectileScript>().StartObject(damagePoints, releaseObject.GetComponent<ReleaseObjectTelemetry>().ProjectileSpeed*dir);

            
        }
    }
}