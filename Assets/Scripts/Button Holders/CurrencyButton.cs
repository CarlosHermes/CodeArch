using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CurrencyButton : MonoBehaviour
{
    private Button _button;
    public IntVariable _var;
    public Text _text;

    public void OnValidate()
    {
        if (_button == null)
            _button = GetComponent<Button>();
        _text.text = _var ? _var.Value.ToString() : null;
    }
}
