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
    Slider _exSlider;
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
        _exSlider.maxValue = 3;
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

        _exSlider.value = _exCount;
    }

    public void GameClear()
    {
        _clear.text = "GAMECLEAR!!";
    }

}
