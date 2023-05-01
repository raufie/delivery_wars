using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public Button StartButton;
    public Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        StartButton.onClick.AddListener(()=>{
            SceneManager.LoadScene(1);
        });
        QuitButton.onClick.AddListener(()=>{
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
