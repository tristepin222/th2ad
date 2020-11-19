using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    
    GameObject canva;
    CinemachineVirtualCamera cm;
    GameObject player;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
       
       canva = GameObject.FindGameObjectWithTag("MainMenu");
       cm = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
        cm.Follow = player.transform;
       canva.SetActive(false);

       
    }
    
}
