using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropBox : MonoBehaviour, IDropTarget
{
    TextMeshProUGUI _text;
    int _itemsCountInBox;
    Animator[] _animators;

    public static event Action OnBoxFilled;
    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _animators = GetComponentsInChildren<Animator>();
    }

    public void OnDrop()
    {
        _itemsCountInBox++;
        switch (_itemsCountInBox)
        {
            case 1:
                _text.color = Color.green;
                _text.text = $"{_itemsCountInBox}/3";
                break;
            case 2:
                _text.color= Color.yellow;
                _text.text = $"{_itemsCountInBox}/3";
                break;
            case 3:
                _text.color= Color.grey;
                _text.text = $"{_itemsCountInBox}/3";
                foreach (Animator animator in _animators)
                {
                    animator.enabled = true;
                }
                OnBoxFilled?.Invoke();
                GetComponent<Collider>().enabled = false;   
                this.enabled = false;
                break;

            default:
                break;
        }
    }
}
