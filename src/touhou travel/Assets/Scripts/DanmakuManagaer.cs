using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuManagaer : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] public float bulletSpeed;
    public PlayerManagament player;
    public int cooldownDanmakuMax;
    public int bulletAmount;
    private Vector3 target;
    private Vector3 difference;
    private int cooldownDanmaku = 0;
    void Start()
    {
        GameObject GPlayer = GameObject.FindGameObjectWithTag("Player");
        player = GPlayer.GetComponent<PlayerManagament>();
    }
   
    // Update is called once per frame
    void Update()
    {

        if (cooldownDanmaku >= cooldownDanmakuMax)
        {
            target = player.transform.position;
                difference = target - this.transform.position;

                difference.Normalize();
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                LaunchProjectile(direction, rotationZ);
          
            cooldownDanmaku = 0;
        }
    }
    private void LaunchProjectile(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(projectile) as GameObject;

        b.transform.position = this.GetComponent<Transform>().position;

        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        for(int i = 0; i < b.transform.childCount; i++)
        {
            Rigidbody2D c = b.transform.GetChild(i).GetComponent<Rigidbody2D>();
            Vector2 direction2 = Vector2.MoveTowards(c.GetComponent<Transform>().position, new Vector2(10, 10), 0.1f) / bulletSpeed;
            c.velocity = direction2;
        }
        
    }
    private void FixedUpdate()
    {
        cooldownDanmaku++;
    }
}
