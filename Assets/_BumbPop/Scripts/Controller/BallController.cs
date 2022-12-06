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

    public Transform directionVector;
    
    private Vector3 _direction;
    private float _power;
    
    private Touch _touch;

    private Vector3 _dragStart;
    private Vector3 _dragEnd;
    private Vector3 _dragging;

    public LineRenderer lineRenderer;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Distance();
        selectingBall = Distance();

        directionVector.transform.position = selectingBall.transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            _dragStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _dragging = Input.mousePosition - _dragStart;
            directionVector.rotation = Quaternion.Euler(directionVector.rotation.x, _dragging.x,directionVector.rotation.z);
            Debug.LogWarning(_dragging + "dragging");
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            selectingBall.transform.forward = directionVector.forward;
            _dragEnd = Input.mousePosition;
            _power = (_dragEnd - _dragStart).sqrMagnitude;
            selectingBall.GetComponent<Rigidbody>().AddForce(selectingBall.transform.forward * 1000, ForceMode.Impulse);



        }
        }




        

    }

    private Ball Distance()
    {
         var temp = activeBalls.OrderBy(t => t.distance).ToList();
         return temp[0];
    }
    
}
