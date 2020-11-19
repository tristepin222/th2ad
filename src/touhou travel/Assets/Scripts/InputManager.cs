using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    GameObject canva;
    private KeyCode esc = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.FindGameObjectWithTag("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(esc))
        {
            
            canva.SetActive(true);
        }
    }

  
}
