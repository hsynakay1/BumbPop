using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //vector3.reflect
    Rigidbody rigidbody;
    public float distance;
    private int _maxBall = 25;

    private float calculater;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        BallController.Instance.activeBalls.Add(this);
    }

    private void Update()
    {
        distance = (GameManager.Instance.finishLine.position - transform.position).sqrMagnitude;
        calculater = Vector3.Distance(BallController.Instance.selectingBall.transform.position, transform.position);
        if (calculater > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            rigidbody.AddRelativeForce(Vector3.forward * .5f,ForceMode.Impulse);
            gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0, 1);
            Debug.LogWarning(BallController.Instance.activeBalls.Count);
            
            if (BallController.Instance.activeBalls.Count <= _maxBall)
            {
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(this);
                }
                
            }
            
        }
     }

    
}
