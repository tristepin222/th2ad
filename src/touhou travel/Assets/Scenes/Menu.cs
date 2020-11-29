using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Menu : MonoBehaviour
{
    
    GameObject canva;
    CinemachineVirtualCamera cm;
    GameObject player;
    [SerializeField] PlayerManagament playerM;
  
    private void Awake()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
        cm = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Play()
    {
      
        player.SetActive(true);
        cm.Follow = player.transform;
       canva.SetActive(false);
        player.transform.position = new Vector2(0, 0);
        playerM.setLife();
       
    }
    
}
