using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootSystem : MonoBehaviour
{
    public TypeScriptable tType;
    public EnemiManagament enemi;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        this.inventory = enemi.GetInventory();
        Type type = new Type { type = tType };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
