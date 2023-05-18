using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstimatedBidPriceText : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void SetInitialText(int startPrice)
    {
        _text.text = ((int)((float)startPrice - ((float)startPrice * 0.05f))).ToString();
    }
}
