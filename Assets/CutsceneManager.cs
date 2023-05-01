using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutsceneManager : MonoBehaviour
{
    public string [] Texts;
    public Sprite [] Images;
    public float [] Times;
    public int nextScene;
    private float T0;
    private int currentSlide;
    public Image slideImage;
    public TMP_Text slideText;
    // public 
    void Start(){
        Screen.SetResolution(1280, 720, true);
        currentSlide = -1;
        NextSlide();
        // FadeIn();
    }

    void FadeIn(){

    }
    void FadeOut(){

    }
    void FixedUpdate(){
        if(Time.time > T0+Times[currentSlide] ){
            if(currentSlide+1 < Times.Length){
            NextSlide();
            }else{
                SceneManager.LoadScene(nextScene);
            }

        }
        
    }
    void NextSlide(){
        currentSlide+=1;
        slideImage.sprite = Images[currentSlide];
        slideText.text = Texts[currentSlide];
        T0 = Time.time;
    }

}
