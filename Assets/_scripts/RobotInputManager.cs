using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Input;
public class RobotInputManager : MonoBehaviour
{
    public RobotController controller;
    public WeaponsManager weaponsManager;
    public HUDManager hudManager;
        // Start is called before the first frame update
    void Start()
    {
        weaponsManager = GameObject.FindGameObjectWithTag("WeaponsManager").GetComponent<WeaponsManager>();
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)){
            controller.Move(-1);
        }
        if (Input.GetKey(KeyCode.D)){
            controller.Move(1);
        }
        if (Input.GetKey(KeyCode.Space)){
            controller.Thrust();
        }
      

        if( Input.GetButtonDown("Fire1")){
            controller.Fire();
        }

      

        if (Input.GetKeyDown(KeyCode.Tab)){
            
            hudManager.SetWeapon((int)weaponsManager.currentWeapon);
            if(weaponsManager.GetCurrentWeapon() is SurprizeWeapon){
                hudManager.SetAmmo(weaponsManager.GetCurrentWeapon().ammo);
            }else{
                hudManager.SetAmmo(-1);
            }
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().toggleController();
        }
    }
}
