using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    GameObject canva;
    CinemachineVirtualCamera cm;
    GameObject player;
    
  
    private void Awake()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
        if(GlobalControl.Instance != null)
        {
            SceneManager.LoadScene(GlobalControl.Instance.lastScene);
        }
        else{
            SceneManager.LoadScene("Game");
        }


        
       
       
    }
    
}
