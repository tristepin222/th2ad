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
    [SerializeField] bool is_menu;
    [SerializeField] bool inside;





    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnUnloadScene;
        
      
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void  OnUnloadScene(Scene scene)
    {
      
        GlobalControl.Instance.life = player_managament.life;
        
        GlobalControl.Instance.inventory = player_managament.inventory;
        GlobalControl.Instance.vc = vc;
       

    }
    
    
}
