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



        SceneManager.LoadScene(GlobalControl.Instance.lastScene);
       
       
    }
    
}
