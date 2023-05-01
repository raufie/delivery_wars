using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{

    

    public WeaponBase weapon;
    public string Name;
    public float FireRate;
    public int damagePoints;
    public int maxAmmo;
    public int ammo;
    public GameObject releaseObject;
    public float AttackDistance = 10f;
    
    public WeaponsManager.WEAPON type;
    

    private Dictionary<WeaponsManager.WEAPON, System.Type> weaponClasses = new Dictionary<WeaponsManager.WEAPON, System.Type>() {
        {WeaponsManager.WEAPON.MELEE, typeof(MeleeWeapon)},
        {WeaponsManager.WEAPON.REVOLVER, typeof(RevolverWeapon)},
        {WeaponsManager.WEAPON.SHOTGUN, typeof(ShotgunWeapon)},
        {WeaponsManager.WEAPON.SURPRIZE, typeof(SurprizeWeapon)}
    };

    
    // Start is called before the first frame update
    void Start()
    {
       
        System.Type WeaponClass = weaponClasses[type];
        weapon = (WeaponBase) System.Activator.CreateInstance(WeaponClass , new object []{ Name, FireRate, damagePoints, maxAmmo, ammo, releaseObject, AttackDistance});

    }

    void Update(){
        Vector2 direction = transform.right;
        Ray2D ray = new Ray2D(transform.position, direction);

        Debug.DrawRay(ray.origin, ray.direction * AttackDistance, Color.red);
    }
}
