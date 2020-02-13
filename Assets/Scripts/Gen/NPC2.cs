using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2 : MonoBehaviour
{
    [SerializeField]
    Renderer ren2 = null;
    [SerializeField]
    Event en2 = null;

    bool Entry2 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Color Co = ren2.material.color;
        Co.a = 0f;
        ren2.material.color = Co;
    }

    // Update is called once per frame
    void Update()
    {
        Color Co = ren2.material.color;
        if (en2.NPC2)
        {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("↑");
                   Co.a = 1.0f;
                    ren2.material.color = Co;
                    Invoke("ChatEnd", 3);
                }
        }
        ren2.material.color = Co;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        en2.NPC2 = true;
        Debug.Log("En");

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ex");
        en2.NPC2 = false;
    }
    void ChatEnd()
    {
        Color Co = ren2.material.color;
        Co.a = 0.0f;
        ren2.material.color = Co;
    }
}
