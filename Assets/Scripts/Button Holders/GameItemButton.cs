using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameItemButton : MonoBehaviour
{
    protected Button _button;
    public ScriptableItem _item;

    public ScriptableItem Item
    {
        get => _item;
        set
        {
            _item = value;
            UpdateSelf();
        }
    }

    [SerializeField]
    protected Image _image;
    [SerializeField]
    protected Text _text;

    public virtual void UpdateSelf()
    {
        if (_button == null)
            _button = GetComponent<Button>();
        if (_image && _item) _image.sprite = _item.Icon;
        if (_text && _item) _text.text = $"{_item.Amount}";
    }

    public void OnValidate() => UpdateSelf();

    public void SelectItem()
    {
        if (_item is SkillItem skill)
            DBow.ActiveSkill = skill;
    }
}