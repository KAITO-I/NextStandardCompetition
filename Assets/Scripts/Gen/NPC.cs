using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField]
    Renderer ren = null;
    [SerializeField]
    Event en = null;

    bool Entry = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Color Co = ren.material.color;
        Co.a = 0f;
        ren.material.color = Co;
    }

    // Update is called once per frame
    void Update()
    {
        Color Co = ren.material.color;
        

        if (en.NPC1)
        {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("↑");
                    Co.a = 1.0f;
                    ren.material.color = Co;
                    Invoke("ChatEnd", 3);
                }
        }
        ren.material.color = Co;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        en.NPC1 = true;
        Debug.Log("En");

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ex");
        en.NPC1 = false;
    }
    void ChatEnd()
    {
         Color Co = ren.material.color;
         Co.a = 0.0f;
        ren.material.color = Co;
    }
}
