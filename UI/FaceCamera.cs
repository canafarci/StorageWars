using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Start()
    {
        transform.LookAt(Camera.main.transform.position);
    }

}
