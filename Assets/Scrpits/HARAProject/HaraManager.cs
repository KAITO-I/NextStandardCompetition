using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaraManager : MonoBehaviour
{
    int _exCount;
    [SerializeField]
    Text _clear;
    [SerializeField]
    Transform _countBerPos;
    [SerializeField]
    GameObject _yellowObject;
    [SerializeField]
    GameObject[] _exCountImage;
    
    float _time;
    public bool _start;
    public int GetSetEx
    {
        get  { return _exCount; }
        set { _exCount = value; }
    }
    public bool _exBarstChack;//発動できるかどうか
    public bool _exChack;//発動したかどうか

    private void Start()
    {
        _clear.text = "";
        _start = false;
        _time = 3f;
        GetSetEx = 0;
        foreach(var v in _exCountImage)
        {
            v.SetActive(false);
        }
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        string str = string.Format("{0:0}", _time);
        _clear.text = str;
        if (_time < 0)
        {
            _start = true;
            _clear.text = "";
        }
        for(int i = 0; i < _exCountImage.Length; ++i)
        {
            if (i < GetSetEx)
            {
                _exCountImage[i].SetActive(true);
            }
            else
            {
                _exCountImage[i].SetActive(false);
            }
        }
    }

    public void GameClear()
    {
        _clear.text = "GAMECLEAR!!";
    }

}
