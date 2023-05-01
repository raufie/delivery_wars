using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public enum WEAPON {
        MELEE, 
        REVOLVER,
        SHOTGUN,
        SURPRIZE
    }
    
    public GameObject Sword;
    public float SwordDefaultRotation;
    public HUDManager hudManager;
    public WeaponObject[] Weapons;

    public WEAPON currentWeapon;

    void Start(){
        SwordDefaultRotation = Sword.transform.eulerAngles.z;
        SwitchWeapon(0);
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();

    }
    // Start is called before the first frame update
    public void Fire(){
        if((int)currentWeapon == 0){
            Sword.transform.eulerAngles = new Vector3(0f,0f,-90f);
            StartCoroutine(PlaySword());
        }
        Weapons[(int)currentWeapon].weapon.Fire();
        if(Weapons[(int)currentWeapon].weapon is SurprizeWeapon){
            hudManager.SetAmmo(Weapons[(int)currentWeapon].weapon.ammo);
        }else{
            hudManager.SetAmmo(-1);
        }
    }
    public void SwitchWeapon(int type){
        if(hudManager == null){
            hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();
        }
        if (type < Weapons.Length){
            for(int i = 0; i < Weapons.Length; i++){

                if( i== type){
                    currentWeapon = (WEAPON)type;
                    Weapons[i].gameObject.SetActive(true);
                    
                    hudManager.SetWeapon(i);        
                    if(Weapons[i].weapon is SurprizeWeapon){
                        hudManager.SetAmmo(Weapons[i].ammo);
                    }else{
                        hudManager.SetAmmo(-1);
                    }
                }else{
                    currentWeapon = (WEAPON)type;
                    Weapons[i].gameObject.SetActive(false);
                }
            }

            
        }

        
    }

    public WeaponBase GetCurrentWeapon(){
        return Weapons[(int)currentWeapon].weapon;
    }
    public void AddSurprizes(int Ammo){
        Weapons[(int)currentWeapon].weapon.AddAmmo(Ammo);
    }
    private IEnumerator PlaySword()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(0.1f);

        // Load the new scene
        // return to normal
    Sword.transform.eulerAngles = new Vector3(0f,0f,SwordDefaultRotation);
    }
}
