using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class sceneManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerManagament player_managament;

    [SerializeField] GameObject vc;
    [SerializeField] bool is_menu;
   

    private Vector3 v;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnUnloadScene;
        SceneManager.sceneUnloaded += OnloadScene;
      
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void  OnUnloadScene(Scene scene)
    {
        GlobalControl.Instance.life = player_managament.life;
        GlobalControl.Instance.v = player.transform;
        GlobalControl.Instance.inventory = player_managament.inventory;
        GlobalControl.Instance.vc = vc;
       
    }
    private void OnloadScene(Scene scene)
    {
        if (scene.name == "MainMenu")
        {
            player.transform.position = GlobalControl.Instance.v.position;
        }
        else
        {
            player.transform.position = new Vector3(0, 0, 0);
        }
        player_managament.life = GlobalControl.Instance.life;
        player_managament.inventory = GlobalControl.Instance.inventory;
        
    }
    
}
