using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour
{
    [SerializeField] public Transform transform;
   
    [SerializeField] public Vector3 v;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnloadScene;
       
    }
    private void OnloadScene(Scene scene, LoadSceneMode loadScene)
    {


        if (this != null)
        {
            GlobalControl.Instance.player.transform.position = this.gameObject.transform.position;

        }
    }
  
}
