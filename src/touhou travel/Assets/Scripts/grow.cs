using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class grow : MonoBehaviour
{
    private Sprite s;
    private SpriteRenderer sr;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] public int growTime;
    private int a = 0;
    private int i = 0;
   

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

  
    private void FixedUpdate()
    {
        a++;
        if(a >= growTime)
        {
            if (i < sprites.Count)
            {
                sr.sprite = sprites[i];
                i++;
                a = 0;
            }
        }
    }
}
