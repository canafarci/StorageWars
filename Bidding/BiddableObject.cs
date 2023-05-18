using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddableObject : MonoBehaviour
{
    [SerializeField] BidConfigScriptableObject _bidConfig;
    PositionLerper _positionLerper;
    EstimatedBidPriceText _priceText;
    AcceptButton _acceptButton;
    TransformLerper _transformLerper;

    private int _totalBids;
    int _currentBid;

    private void Awake()
    {
        _totalBids = _bidConfig.BidAmounts.Length;
        _positionLerper = FindObjectOfType<PositionLerper>();
        _priceText = FindObjectOfType<EstimatedBidPriceText>();
        _acceptButton = FindObjectOfType<AcceptButton>(true);
        _transformLerper = GetComponentInChildren<TransformLerper>();
    }

    private void Start()
    {
        _positionLerper.LerpObjectIn(this.transform);
        _priceText.SetInitialText(_bidConfig.BidAmounts[0]);
        _acceptButton.OnNewObjectSpawn();
    }

    public void SecondStage()
    {
        StartCoroutine(_transformLerper.LerpTransform());
    }

    public void ExitObject()
    {
        _positionLerper.LerpObjectOut(this.transform);
        Destroy(this.gameObject, 3f);
    }
    public int BiddingLoop()
    {
        if (_currentBid < _totalBids)
        {
            return GetBidPrice(_currentBid);
        }
        else
        {
            return 0;
        }
    }

    private int GetBidPrice(int index)
    {
        _currentBid++;
        int price = _bidConfig.BidAmounts[index];
        _acceptButton.CurrentPrice = price;
        return price;
    }
}
