using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    public int Health;
    public int MaxHealth = 100;
    public HUDManager hudManager;
    // Start is called before the first frame update
    void Start()
    {
        hudManager = GameObject.FindGameObjectWithTag("HUDManager").GetComponent<HUDManager>();
    }

    public void AddHealth(int Health){
        if (Health + this.Health > MaxHealth){
            this.Health = MaxHealth;
        }else{
            this.Health+= Health;
        }
        if(gameObject.tag == "robot"){
            hudManager.SetRobotHealth(Health);
        }else{
            hudManager.SetPlayerHealth(Health);
        }
    }
    public void takeDamage(int damage){
        if(Health - damage <= 0 ){
            Health = 0;
            SceneManager.LoadScene(3);
        }else {
            Health -= damage;
        }
        if(gameObject.tag == "robot"){
            hudManager.SetRobotHealth(Health);
        }else{
            hudManager.SetPlayerHealth(Health);
        }
    }
}
