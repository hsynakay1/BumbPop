using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{
    public static BallController Instance;

    public List<Ball> activeBalls = new List<Ball>();
    public Ball selectingBall;
    public Ball spawnBall;
    public int maxBall = 50;
    public Transform directionVector;

    private Vector3 _direction;
    
    public float _power;
    public Transform startPoint;
    
    private Touch _touch;

    private Vector3 _dragStart;
    private Vector3 _dragEnd;
    private Vector3 _dragging;

    public LineRenderer lineRenderer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    { 
        directionVector.transform.position = selectingBall.transform.position;

        if (activeBalls.Count >= 1)
        {
            
            Distance();
            selectingBall = Distance();
        }

        /*if (activeBalls.Count > maxBall)
        {
            for (int i = maxBall; i < activeBalls.Count; i++)
            {
                activeBalls.Remove(activeBalls[i]);
            }
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            _dragStart = Input.mousePosition;
            
        }

        if (Input.GetMouseButton(0))
        {
            _dragging = Input.mousePosition - _dragStart;
            directionVector.rotation =
                Quaternion.Euler(directionVector.rotation.x, _dragging.x, directionVector.rotation.z);

            lineRenderer.SetPosition(0,directionVector.transform.position);
            lineRenderer.SetPosition(1, directionVector.transform.forward * 10);
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectingBall.transform.forward = directionVector.forward;
            _dragEnd = Input.mousePosition;
            selectingBall.GetComponent<Rigidbody>().AddForce(selectingBall.transform.forward * _power, ForceMode.Impulse);
            GameManager.Instance.gameState = GameState.Action;
        }
    }
    public Ball Distance()
    {
        Debug.LogError("girdi");
        var temp = activeBalls.OrderBy(t => t.distance).ToList();
        return temp[0];
    }


}