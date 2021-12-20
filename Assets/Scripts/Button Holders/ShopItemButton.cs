using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : GameItemButton
{
    public override void UpdateSelf()
    {
        if (_button == null)
            _button = GetComponent<Button>();
        _image.sprite = _item && _image ? _item.Icon : null;
        _text.text = _item && _text ? $"{_item.Price}" : null;
    }
}
