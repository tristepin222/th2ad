using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemiManagament : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public int health;
    [SerializeField] public TypeScriptable tType;
    [SerializeField] public GameObject loot;
    [SerializeField] AudioSource  audio;
    [SerializeField]  public PlayerManagament player;
    private LifeManagament life;
    public EventHandler hit;
    public Type type;
    UnityEngine.Random rand;
   public Item item;
    private int cooldown = 0;
    private int cooldownDanmaku = 0;
    public int cooldownMax;
    public int cooldownDanmakuMax;
    public int bulletAmount;
    private Vector3 target;
    private Vector3 difference;
    private bool is_active = false;
    private Renderer renderer;
    void Awake()
  {        
        life = new LifeManagament(health);
        rand = new UnityEngine.Random();
        type = new Type { type = tType };
        GameObject GPlayer = GameObject.FindGameObjectWithTag("Player");
       player = GPlayer.GetComponent<PlayerManagament>();
        life.isPLayer = false;
         renderer = this.gameObject.GetComponent<Renderer>();
        player.OnDeath += OnPlayerDeath;
      
    }

    public void OnHit()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ProjectilePlayer")
        {
            projectileManager projecile = other.gameObject.GetComponent<projectileManager>();
            if (!projecile.isBeam)
            {


                Destroy(other.gameObject);
            }
            life.reduceLife(projecile.getDamage()) ;
        }
    }
    private void Update()
    {
      

        

        if (life.lifeAmount <= 0)
        {
            Destroy(this.gameObject);
            audio.Stop();
            SpawnItemInWorld();
            player.GetLife().addLife(1);
        }

        if (is_active)
        {
            
            if (cooldown >= cooldownMax)
            {
                target = player.transform.position;
                difference = target - this.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                LaunchProjectile(direction, rotationZ);

                cooldown = 0;
            }
        }
        
        
    }
    private void FixedUpdate()
    {
        cooldown++;
        cooldownDanmaku++;
    }
    private void OnBecameInvisible()
    {
        is_active = false;
        audio.Pause();
    }
    private void OnBecameVisible()
    {
        is_active = true;
        if (!audio.isPlaying)
        {
            audio.UnPause();
        }
    }
    private void randomDrop()
    {
        int randInt = UnityEngine.Random.Range(0, 1);

        switch (randInt)
        {
            default:
            case  0:  item = new Item(); break;
            case 1:  item = new Item(); break;
        }
    }
    private void LaunchProjectile(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(projectile) as GameObject;
        
            b.transform.position = this.GetComponent<Transform>().position;
      
       b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
      
    
    public void SpawnItemInWorld()
    {
        loot = Instantiate(loot) as GameObject;
        loot.transform.position = this.transform.position;
    }
    private void OnPlayerDeath(object sender, System.EventArgs e)
    {
        audio.Pause();
    }
   
}
