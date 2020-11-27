using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManagament : MonoBehaviour
{
 
    [SerializeField] private UI_Inventory uiInventory;
    private Vector2 selfTransform;
    [SerializeField] private UI_Life uiLife;
    [SerializeField] ProjectileScriptableObject projectileScriptableObject;
    [SerializeField] int amount;
    [SerializeField] GameObject projectile;
    private static Inventory inventory;

[SerializeField] string typeName;
 [SerializeField] private  Collider2D collider2DC;
 private Type type;
private LifeManagament life;
    private GameObject canva;
    private ProjectileManagament projectileManagament;
    [SerializeField] GameObject projectilePreFab;



    private KeyCode esc = KeyCode.Escape;
   

    private  void Awake() {
      type = new Type(typeName);
        inventory = new Inventory();
        life = new LifeManagament(3);
        projectileManagament = new ProjectileManagament(projectileScriptableObject, amount);
    uiInventory.SetInventory(inventory);
        
    uiLife.setLifeUI(life);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
    public Collider2D GetCollider2D()
    {
        return collider2DC;
    }
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
         
        
    }
    void Update()
    {
        
        if (Input.GetKeyDown(esc))
        {
            
            canva.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {


            LaunchProjectile();
        }

    }

    private void LaunchProjectile()
    {
        GameObject b = Instantiate(projectile);
        b.transform.position = this.GetComponent<Transform>().position;
    }
    

}

