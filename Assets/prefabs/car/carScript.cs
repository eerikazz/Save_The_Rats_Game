using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class carScript : MonoBehaviour
{
    private SplineAnimate splineAnimate;
    
    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
    }

    void Update()
    {
        if (splineAnimate != null)
        {
            if (splineAnimate.ElapsedTime >= splineAnimate.Duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
