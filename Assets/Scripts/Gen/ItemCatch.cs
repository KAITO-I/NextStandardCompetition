using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatch : MonoBehaviour
{
    bool Iget = false;

    [SerializeField]
    Event Eve = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Event E = Eve.GetComponent<Event>();
        if (Iget)
        {
            if (gameObject.name == "ItemGold")
            {
                E.GoldMedal = true;
                Iget = false;
                Destroy(gameObject);
            }
            else if (gameObject.name == "ItemWTF")
            {
                E.WTF = true;
                Iget = false;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Iget = true;
    }
}
