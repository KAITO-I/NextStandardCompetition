using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaraManager : MonoBehaviour
{
    int _exCount;
    public int GetSetEx
    {
        get  { return _exCount; }
        set { _exCount = value; }
    }
    public bool _exBarstChack;//発動できるかどうか
    public bool _exChack;//発動したかどうか

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
