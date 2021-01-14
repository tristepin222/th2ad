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
    [SerializeField] Vector3 v;






    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnUnloadScene;
        SceneManager.sceneLoaded += OnloadScene;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnloadScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Game")
        {
            GlobalControl.Instance.player.transform.position = GlobalControl.Instance.v3;
        }
        
    }
  private void  OnUnloadScene(Scene scene)
    {
      
        GlobalControl.Instance.life = player_managament.life;
        GlobalControl.Instance.inventory = player_managament.inventory;
        if (scene.name == "Game")
        {
            GlobalControl.Instance.v3 = player.transform.position - new Vector3(0,1,0);
        }
        
       

    }
    
    
}
