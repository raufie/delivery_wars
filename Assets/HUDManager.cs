using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// HEALTH🔁✅
// CURRENT WEAPON🔁✅
// CURRENT MILESTONE🔁
// current player 🔁✅
public class HUDManager : MonoBehaviour
{
    public GameObject PlayerControlledLine;
    public GameObject RobotControlledLine;

    public TMP_Text milestoneText;

    public Sprite ShotgunSprite;
    public Sprite RevolverSprite;
    public Sprite SwordSprite;
    public Sprite SurprizeSprite;
    public Sprite MissileSprite;

    public Image currentWeaponImage;

    public TMP_Text PlayerHealth;
    public TMP_Text RobotHealth;
    public TMP_Text Ammo;

    public GameObject TelemetryObject;

    public TMP_Text VelocityX;
    public TMP_Text VelocityY;
    public TMP_Text Distance;

    public GameObject Guide;



    public void SetVelocity(float x, float y){
        VelocityX.text = ""+(int)x;
        VelocityY.text = ""+(int)y;
    }
    public void SetDistance(float d){
        Distance.text = ""+(int)d;
    }
    public void EnableTelemetry(){
        TelemetryObject.SetActive(true);
    }
    public void EnablePlayer(){
        PlayerControlledLine.SetActive(true);
        RobotControlledLine.SetActive(false);
    }
    public void EnableRobot(){
        PlayerControlledLine.SetActive(false);
        RobotControlledLine.SetActive(true);
        currentWeaponImage.sprite = MissileSprite;
    }
    public void SetWeapon(int type){
        if(type == 0){
            currentWeaponImage.sprite = SwordSprite;
        }else if (type == 1){
            currentWeaponImage.sprite = RevolverSprite;
        }else if (type == 2){
            currentWeaponImage.sprite = ShotgunSprite;
        }else if (type == 3){
            currentWeaponImage.sprite = SurprizeSprite;
        }
    }

    public void SetAmmo(int Ammo){
        if(Ammo == -1){
            this.Ammo.text = "∞";
        }else{
            this.Ammo.text = ""+Ammo;
        }
    }

    public void SetRobotHealth(int Health){
        RobotHealth.text = "ROBOT HEALTH: "+Health;
    }
    public void SetPlayerHealth(int Health){
        PlayerHealth.text = "BRUH HEALTH: "+Health;
    }

    public void SetMilestoneText(string s){
        milestoneText.text = s;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowGuideCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ShowGuideCoroutine()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(10f);

        // Load the new scene
        Guide.SetActive(false);
    }
}
