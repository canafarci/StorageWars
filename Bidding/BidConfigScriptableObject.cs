using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "(ENTER PREFAB NAME) Bid Config", menuName = "Bidding/Bid Config", order = 1)]
public class BidConfigScriptableObject : ScriptableObject
{
    [SerializeField] float _originalPrice;
    [SerializeField] float _bidsToOffer;
    [Range(0f, 1f)] [SerializeField] float _startOffset;
    [Range(1f, 2f)] [SerializeField] float _endOffset;

    public int[] BidAmounts { get { return GetBids(); } }
    public int[] GetBids()
    {
        List<int> bids = new List<int>();
        float range = _originalPrice * (_endOffset - _startOffset);

        for (int i = 0; i < _bidsToOffer; i++)
        {
            float bid = _originalPrice - (range / 2) + ((range / _bidsToOffer) * i);
            bids.Add((int)bid);
        }

        int[] bidArray = bids.ToArray();
        return bidArray;
    }
}
