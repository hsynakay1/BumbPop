using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    public GameObject checkObject;
    public void CountBall()
    {
        Collider[] hitCol = Physics.OverlapBox(checkObject.transform.position, checkObject.transform.localScale);
    }

    private void OnDestroy()
    {
        
    }
}
