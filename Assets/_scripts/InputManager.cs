using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Input;
public class InputManager : MonoBehaviour
{
    public CharacterController controller;
    public WeaponsManager weaponsManager;
    public HUDManager hudManager;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space)){
            controller.Jump();
        }
        if( Input.GetKeyDown(KeyCode.Alpha1)){
            weaponsManager.SwitchWeapon(0);
            hudManager.SetWeapon(0);
        }
        if( Input.GetKeyDown(KeyCode.Alpha2)){
            hudManager.SetWeapon(1);
            weaponsManager.SwitchWeapon(1);
        }
        if( Input.GetKeyDown(KeyCode.Alpha3)){
            hudManager.SetWeapon(2);
            weaponsManager.SwitchWeapon(2);
            
        }
        if( Input.GetKeyDown(KeyCode.Alpha4)){
            hudManager.SetWeapon(3);
            weaponsManager.SwitchWeapon(3);
        }

        if( Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.LeftControl)){
            weaponsManager.Fire();
        }

        if (Input.GetKeyDown(KeyCode.E)){

        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().toggleController();
        }
    }
}
