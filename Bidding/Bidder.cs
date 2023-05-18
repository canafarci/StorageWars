using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Bidder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _canvas;
    [SerializeField] Animator _animator;
    

    private void OnEnable() => BiddingController.OnBiddingLoop += OnLoop;
    private void OnDisable() => BiddingController.OnBiddingLoop -= OnLoop;

    private void Start()
    {
        int randint = UnityEngine.Random.Range(0, 2);
        float randomIdleStart = UnityEngine.Random.Range(0, _animator.GetCurrentAnimatorStateInfo(0).length);

        if (randint == 0)
            _animator.Play(AnimationHashes.Idle1, 0, randomIdleStart);
        else
            _animator.Play(AnimationHashes.Idle2, 0, randomIdleStart);
    }

    private void OnLoop() => _canvas.SetActive(false);

    public void OnBidForItem(int price)
    {
        _canvas.SetActive(true);
        _text.text = price.ToString() + "$";
        _animator.Play(AnimationHashes.BidAnimation);
    }

    public void OnBidAccepted()
    {
        _animator.Play(AnimationHashes.BidAcceptAnimation);
    }

}
