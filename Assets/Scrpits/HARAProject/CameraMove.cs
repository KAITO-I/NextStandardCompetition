using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    bool MoveChack;
    [SerializeField]
    float speed;
    HaraManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindWithTag("Manager").GetComponent<HaraManager>();
        MoveChack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_manager._start)//カメラが動いているかどうか
        {
            gameObject.transform.position += new Vector3(speed * 1 * Time.deltaTime, 0, 0);
        }

    }
}
