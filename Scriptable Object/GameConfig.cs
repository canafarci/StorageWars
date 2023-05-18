using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/New Config", order = 0)]
public class GameConfig : ScriptableObject
{
    public int StartMoney;

    [Header("AUDIO")]

    public AudioConfig DragStartConfig;
    public AudioConfig StorageBuyConfig;
    public AudioConfig ChestConfig;
    public AudioConfig BiddingLoopConfig;
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip Audio;
    public float Volume;
}
