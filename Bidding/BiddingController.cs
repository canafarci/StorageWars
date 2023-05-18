using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class BiddingController : MonoBehaviour
{
    [SerializeField] GameObject[] _objectsToBid;
    [SerializeField] Transform _bidObjectSpawn;
    [SerializeField] GameObject _nextButton;
    [SerializeField] ParticleSystem _vfx1, _vfx2;
    Queue<GameObject> _objectsQueue = new Queue<GameObject>();

    GameObject _currentBiddedObject;
    BiddableObject _biddableObject;
    List<Bidder> _bidders = new List<Bidder>();
    Bidder _lastBidder;
    AcceptButton _acceptButton;
    bool _isInFirstStageOfBidding = true;
    int _lastPrice;

    [SerializeField] GameObject _endFX, _bidUI;

    public static event Action OnBiddingLoop;
    private void Awake()
    {
        foreach (GameObject go in _objectsToBid)
        {
            _objectsQueue.Enqueue(go);
        }

        foreach (Bidder bidder in FindObjectsOfType<Bidder>())
        {
            _bidders.Add(bidder);
        }

        _acceptButton = FindObjectOfType<AcceptButton>(true);
    }
    public void StartBidding()
    {
        SpawnObject();
    }

    public void LeftButton()
    {
        if (_isInFirstStageOfBidding)
        {
            _isInFirstStageOfBidding = false;
            _acceptButton.OnBiddingStart();
            _biddableObject.SecondStage();
            _nextButton.SetActive(true);
            BiddingLoop();
        }
        else
        {
            SellItem();
        }

    }

    private void SellItem()
    {
        EndBidding();
        _lastBidder.OnBidAccepted();
        _isInFirstStageOfBidding = true;
        _nextButton.SetActive(false);
        GameManager.Instance.ResourceManager.OnMoneyChange(_lastPrice);
        _vfx1.Play();
        _vfx2.Play();
    }

    public void LoopBids() => BiddingLoop();

    public void EndBidding()
    {
        OnBiddingLoop?.Invoke();

        if (_objectsQueue.Count > 0)
        {
            AudioConfig audioConfig = GameManager.Instance.References.GameConfig.BiddingLoopConfig;
            GameManager.Instance.AudioManager.PlaySFX(audioConfig.Audio, audioConfig.Volume);
            _biddableObject.ExitObject();
            SpawnObject();
        }
        else
        {
            _biddableObject.ExitObject();
            _endFX.SetActive(true);
            GameManager.Instance.SceneLoader.FadedLoadScene(0, 2f);
            _bidUI.SetActive(false);
        }
    }

    private void SpawnObject()
    {
        _currentBiddedObject = Instantiate(_objectsQueue.Dequeue(), _bidObjectSpawn.position, _bidObjectSpawn.rotation, _bidObjectSpawn.parent);
        _biddableObject = _currentBiddedObject.GetComponent<BiddableObject>();
    }

    private void BiddingLoop()
    {
        OnBiddingLoop?.Invoke();
        int price = _biddableObject.BiddingLoop();
        
        if (price != 0)
            BidForItem(price);
        if (price == 0)
            SellItem();
    }

    private void BidForItem(int price)
    {
        int randInt = UnityEngine.Random.Range(0, _bidders.Count);
        Bidder bidder = _bidders[randInt];

        bidder.OnBidForItem(price);
        _bidders.Remove(bidder);

        if (_lastBidder != null)
            _bidders.Add(_lastBidder);

        _lastBidder = bidder;
        _lastPrice = price;
    }
}