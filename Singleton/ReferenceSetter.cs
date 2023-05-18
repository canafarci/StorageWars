using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceSetter : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(PrefKeys.Money))
            GameManager.Instance.Saver.SaveInt(PrefKeys.Money, GameManager.Instance.References.GameConfig.StartMoney);
        
        GameManager.Instance.References.CanvasGroup = GetComponentInChildren<CanvasGroup>();
    }
}