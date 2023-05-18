using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcceptButton : MonoBehaviour
{
    public int CurrentPrice;
    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public void OnNewObjectSpawn()
    {
        _text.text = "Start Bidding!";
    }

    public void OnBiddingStart()
    {
        _text.text = "Accept Offer";
    }
}
