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
    
    private Material _newMaterial;
    private Ball _spawnBall;   
    
    private float calculater;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        distance = (GameManager.Instance.finishLine.position - transform.position).sqrMagnitude;
        calculater = Vector3.Distance(BallController.Instance.selectingBall.transform.position, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallController.Instance.activeBalls.Add(this);
            rigidbody.AddRelativeForce(Vector3.forward * 1.5f,ForceMode.Impulse);
            _newMaterial = collision.gameObject.GetComponent<Renderer>().material;
            gameObject.GetComponent<Renderer>().material = _newMaterial;
            Debug.LogWarning(BallController.Instance.activeBalls.Count);
            
            
            if (BallController.Instance.activeBalls.Count <= BallController.Instance.maxBall)
            {
                for (int i = 0; i < 3; i++)
                {
                    _spawnBall = PoolManager.Instance.GetPoolObject(0);
                    _spawnBall.gameObject.GetComponent<Renderer>().material = _newMaterial;
                    _spawnBall.transform.position = collision.gameObject.transform.position;
                    if (!BallController.Instance.activeBalls.Contains(_spawnBall))
                    {
                        BallController.Instance.activeBalls.Add(_spawnBall);
                    }
                }
            }
        }
    }

    
}
