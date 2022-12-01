using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Serialization;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    
    public List<Ball> activeBalls = new List<Ball>();
    public Ball selectingBall;

    [SerializeField] private float _power;
    [SerializeField] private float _maxDrag;
    [SerializeField] private float _lineRendererLenght;
    
    private Touch _touch;  
    
    private Vector3 _draggingPos;
    private Vector3 _dragVector;
    private Vector3 _dragStartPos;

    public LineRenderer lineRenderer;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.touchCount > 0 )
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (_touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }

    private void DragStart()
    {
        _draggingPos = _touch.position;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,selectingBall.transform.position);
        
    }

    private void Dragging()
    {
        _draggingPos = _touch.position;
        _dragVector = _draggingPos - _dragStartPos;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(1, - Vector3.ClampMagnitude(_dragVector,_power) * (0.1f * _lineRendererLenght));
    }

    private void DragRelease()
    {
        lineRenderer.positionCount = 0;
        
        Vector3 dragReleasePos = _touch.position;
        Vector3 force = _dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, _power);

        selectingBall.rigidbody.AddRelativeForce(clampedForce, ForceMode.Impulse);
    }
    
}
