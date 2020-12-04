using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootSystem : MonoBehaviour
{

    
    [SerializeField] GameObject b;
    private Item item;
    private void Start()
    {
      
       
    }

   public void SpawnItemInWorld(Transform position)
    {
        b = Instantiate(b) as GameObject;
        b.transform.position = transform.position;
    }


}
