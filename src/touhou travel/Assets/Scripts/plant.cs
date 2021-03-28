using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class plant : MonoBehaviour
{
    public Sprite newSprite;
        private Sprite oldSprite;
    private bool planted = false;
    private SpriteRenderer spriter;
    private GameObject Interact;
    private bool entered = false;
    private KeyCode e = KeyCode.E;
    [SerializeField] crops.crop crop;
    [SerializeField] Transform plantC;
    [SerializeField] Collider2D c;
    [SerializeField] PlayerManagament player;
    [SerializeField] Item neededItem;
    private bool canPlant = false;
    // Start is called before the first frame update
    void Start()
    {
        neededItem = new Item { item = Item.ItemType.Hoe };
        Interact = GameObject.FindGameObjectWithTag("Interact");
        spriter = this.GetComponent<SpriteRenderer>();
        if (Interact == null)
        {
            Interact = GlobalControl.Instance.ui_interact;
        }
        

    }
    private void Awake()
    {
        Interact = GameObject.FindGameObjectWithTag("Interact");
        if (Interact == null)
        {
            Interact = GlobalControl.Instance.ui_interact;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            player = GlobalControl.Instance.player.GetComponent<PlayerManagament>();
        }
        if (player.GetInventory().hasItem("Hoe"))
        {
            canPlant = true;
        }
        else
        {
            canPlant = false;
        }
        if (Input.GetKeyDown(e) && entered && !planted)
        {
           
            spriter.sprite = newSprite;
           
            Interact.SetActive(false);
            planted = true;
            Transform g =  GameObject.Instantiate(plantC, this.transform);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canPlant)
        {
            if (other.tag == "Player" && planted == false)
            {

                entered = true;
                Interact.SetActive(true);



            }
        }
    }
}
