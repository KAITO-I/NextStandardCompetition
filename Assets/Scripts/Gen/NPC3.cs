using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC3 : MonoBehaviour
{
    [SerializeField]
    Renderer ren3 = null;
    [SerializeField]
    Event en3 = null;

    bool Entry3 = false;

    // Start is called before the first frame update
    void Start()
    {
        Color Co = ren3.material.color;
        Co.a = 0f;
        ren3.material.color = Co;
    }

    // Update is called once per frame
    void Update()
    {
        Color Co = ren3.material.color;
        if (en3.NPC3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("↑");
                Co.a = 1.0f;
                ren3.material.color = Co;
                Invoke("ChatEnd", 3);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        en3.NPC3 = true;
        Debug.Log("En");

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ex");
        en3.NPC3 = false;
    }
    void ChatEnd()
    {
        Color Co = ren3.material.color;
        Co.a = 0.0f;
        ren3.material.color = Co;
    }

}
