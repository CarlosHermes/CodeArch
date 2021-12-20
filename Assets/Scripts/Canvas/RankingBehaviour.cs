using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingBehaviour : MonoBehaviour
{
    [SerializeField] private ScriptableRanking _sRanking;
    [SerializeField] private List<GameObject> _rList = new List<GameObject>(9);
    public WWWClient wc;
    
    public void ReloadCanvas()
    {
        if (_sRanking)
        {
            int lengh = _sRanking.Value.numberPlayers < _rList.Count ? _sRanking.Value.numberPlayers : _rList.Count;
            for (int i = 0; i < lengh; i++)
            {
                Text[] text;
                text = _rList[i].GetComponentsInChildren<Text>();
                text[0].text = _sRanking.Value.users[i].position;
                text[1].text = _sRanking.Value.users[i].userName;
                text[2].text = _sRanking.Value.users[i].level.ToString();
            }
        }
    }

    public void OnEnable()
    {
        ReloadCanvas();
    }
}
