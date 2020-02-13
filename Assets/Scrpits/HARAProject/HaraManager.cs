using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaraManager : MonoBehaviour
{
    int _exCount;
    Text _clear;
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
    }

    public void GameClear()
    {
        _clear.text = "GAMECLEAR!!";
    }

}
