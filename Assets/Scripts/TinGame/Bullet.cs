using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float angle = 0;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private SpriteRenderer renderer;

    private InstanceBulletList instanceBulletList;
    private bool move = false;
    //private int no = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, angle);
    }

    //初期化
    public void EnabledInit(InstanceBulletList _instanceBulletList)
    {
        move = false;
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
        if (instanceBulletList == null)
        {
            instanceBulletList = _instanceBulletList;
        }
    }

    public void DisEnabledInit()
    {
        move = true;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!move) return;
        if (!renderer.isVisible) instanceBulletList.Destroy();
        transform.position += transform.up * speed * Time.deltaTime;
    }
}