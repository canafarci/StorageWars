using UnityEngine;

public static class CameraStrings
{
    public static string FirstCamera = "FirstCamera";
    public static string SecondCamera = "SecondCamera";
    public static string ThirdCamera = "ThirdCamera";
    public static string FourthCamera = "FourthCamera";
}
public static class PrefKeys
{
    public static string Money = "Money";
}

public static class AnimationHashes
{
    static string _idle1 = "SittingIdle1";
    static string _idle2 = "SittingIdle2";
    static string _endAnimation = "EndAnimation";
    static string _bidAnimation = "BidAnimation";
    static string _bidAcceptAnimation = "BidAcceptAnimation";

    public static int Idle1 { get { return Animator.StringToHash(_idle1); } }
    public static int Idle2 { get { return Animator.StringToHash(_idle2); } }
    public static int EndAnimation { get { return Animator.StringToHash(_endAnimation); } }
    public static int BidAnimation { get { return Animator.StringToHash(_bidAnimation); } }
    public static int BidAcceptAnimation { get { return Animator.StringToHash(_bidAcceptAnimation); } }
}