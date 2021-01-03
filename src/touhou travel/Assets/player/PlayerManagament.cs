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
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject UIGameOver;
    private static Inventory inventory;
    [SerializeField] int cooldownMax;
    [SerializeField] string typeName;
 [SerializeField] private  Collider2D collider2DC;
    [SerializeField] TypeScriptable tType;
    private Type type;
private LifeManagament life;
    private GameObject canva;
    private ProjectileManagament projectileManagament;
    [SerializeField] GameObject projectilePreFab;
    [SerializeField] public float bulletSpeed;
    private int cooldown = 0;
    private Vector3 target;
    private KeyCode esc = KeyCode.Escape;
    private KeyCode xKey = KeyCode.X;
    [SerializeField] public GameObject player;
    [SerializeField] int bulletAmount;
    private  void Awake() {
      type = new Type { type = tType };
        inventory = new Inventory();
        setLife();
        projectileManagament = new ProjectileManagament(projectileScriptableObject, amount);
    uiInventory.SetInventory(inventory);
        life.isPLayer = true;
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
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        if (Input.GetKeyDown(esc))
        {
            
            canva.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            if (cooldown >= cooldownMax)
            {
                for (int i = 0; i < bulletAmount; i++)
                {
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    LaunchProjectile(direction, rotationZ, projectile, i);
                }
                cooldown = 0;
            }
        }
        
            if (life.lifeAmount <= 0)
            {

                UIGameOver.SetActive(true);
                this.player.SetActive(false);
                canva.SetActive(true);
            }
       
        if (Input.GetKeyDown(xKey))
        {
            
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            LaunchProjectile(direction, rotationZ, bomb,  isBomb:true);
        }

    }
    private void FixedUpdate()
    {
        cooldown++;
    }

    private void LaunchProjectile(Vector2 direction, float rotationZ,  GameObject projectile, int offset = 1, bool isBomb = false)
    {


        
        GameObject b = Instantiate(projectile) as GameObject;
        float fOffset = 0.5f;
        if (isBomb)
        {
            b.transform.position = this.GetComponent<Transform>().position;
        }
        else
        {
            if (offset >= 2)
            {
                b.transform.position = this.GetComponent<Transform>().position - new Vector3(fOffset, 0, 0) + new Vector3(0, fOffset, 0);
            }
            else if (offset >= 1)
            {
                b.transform.position = this.GetComponent<Transform>().position + new Vector3(fOffset, fOffset, 0);
            }
            else
            {
                b.transform.position = this.GetComponent<Transform>().position;
            }
        }
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
    
    public LifeManagament GetLife()
    {
        return life;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemiProjectile")
        {
            Destroy(other.gameObject);
            life.reduceLife(1);
        }
        if(other.tag == "collectable")
        {
            GameObject otherB = other.gameObject;
            lootManager loot = otherB.GetComponent<lootManager>();
            inventory.AddInventory(loot.GetItem());
            Destroy(otherB);
        }
    }
    public void setLife()
    {
        life = new LifeManagament(3);
        uiLife.setLifeUI(life);
        UIGameOver.SetActive(false);
    }
}

