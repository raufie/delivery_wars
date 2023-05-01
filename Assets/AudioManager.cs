using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // explosion, revolver, shotgun, knife, RocketLaunch, MissleLaunch

    public AudioClip [] audios;
    public Dictionary<string, int> keyToIndex = new Dictionary<string, int>(){
        {"explosion",0},
        {"revolver",1},
        {"shotgun",2},
        {"knife",3},
        {"rocket",4},
        {"missile",5}
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlaySound(string key){
        GetComponent<AudioSource>().PlayOneShot(audios[keyToIndex[key]]);
    }
}
