using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon: WeaponBase {
    public MeleeWeapon (string name, float fireRate, int damagePoints, int maxAmmo, int ammo, GameObject releaseObject, float AttackDistance):
     base (name, fireRate, damagePoints, maxAmmo, ammo, releaseObject, AttackDistance) {
    }

    public override void Fire(bool limitlessAmmo = true){
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("knife");
        if (IsFireable()){
            // MULTI CAST ONLY
            GameObject [] gameObjects = CastRay();
            
            base.Fire();

            for(int i = 0 ; i < gameObjects.Length; i++){
                gameObjects[i].GetComponent<EnemyBase>().takeDamage(damagePoints);
            }
            Debug.Log("firing");
        }
    }

    public override void FireForEnemy(bool limitlessAmmo = true){
        
        if (IsFireable()){
            // MULTI CAST ONLY
            GameObject [] gameObjects = CastRayForEnemy();
            
            base.Fire();

            for(int i = 0 ; i < gameObjects.Length; i++){

                gameObjects[i].transform.parent.gameObject.GetComponent<PlayerScript>().takeDamage(damagePoints);
            }
        }
    }
}