using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyText : MonoBehaviour
{
    private void OnEnable() => GameManager.Instance.ResourceManager.OnMoneyChanged += OnMoneyChange;
    private void OnDisable() => GameManager.Instance.ResourceManager.OnMoneyChanged -= OnMoneyChange;
    private void OnMoneyChange(int money)
    {
        _text.text = money.ToString() + "$";
    }

    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = GameManager.Instance.Saver.GetInt(PrefKeys.Money).ToString() + "$";
    }
}
