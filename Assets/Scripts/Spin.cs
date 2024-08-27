using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3.0f;

    public enum RotationSpace
    {
        Local = 0,
        Global = 1
    }

    public RotationSpace rotationSpace = RotationSpace.Local;

    // Update is called once per frame
    void Update()
    {
        if (rotationSpace == RotationSpace.Local)
        {
            transform.Rotate(0, speed, 0);
        }
        else
        {
            transform.Rotate(0, speed, 0, Space.World);
        }
    }
}
