using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rigidbody;

    private void Start()
    {
      BallController.Instance.activeBalls.Add(this);
    }
}
