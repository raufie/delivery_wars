using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int PlayerHealth;
    public int RobotHealth;
    public int Rockets;
    public int Surprizes;
    // main sprite
    // Start is called before the first frame update
       void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is a specific type of game object
        if (other.CompareTag("Player") || other.CompareTag("robot"))
        {
            GameObject.FindGameObjectWithTag("WeaponsManager").GetComponent<WeaponsManager>().AddSurprizes(Surprizes);
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().Robot.AddHealth(RobotHealth);
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().Player.AddHealth(PlayerHealth);
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().RobotObject.GetComponent<RobotController>().AddAmmo(Rockets);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
