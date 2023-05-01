using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon: WeaponBase {
    public ShotgunWeapon (string name, float fireRate, int damagePoints, int maxAmmo, int ammo, GameObject releaseObject, float AttackDistance):
     base (name, fireRate, damagePoints, maxAmmo, ammo, releaseObject, AttackDistance) {
    }

    public override void Fire(bool limitlessAmmo = true){
        
        if (IsFireable()){
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("shotgun");
            // MULTI CAST ONLY
            GameObject [] gameObjects = CastRay();
            
            base.Fire();

            if (gameObjects.Length > 0){
                gameObjects[0].GetComponent<EnemyBase>().takeDamage(damagePoints);
            }
            
        }
    }
}