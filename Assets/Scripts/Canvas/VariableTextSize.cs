using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableTextSize : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    public void Resize(int rows)
    {
        _text.fontSize = (int)(_text.fontSize - _text.fontSize * (rows - 2) * 20 / 100);
        Debug.Log("post" + _text.fontSize);
    }
}
