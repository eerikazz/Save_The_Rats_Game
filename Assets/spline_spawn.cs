using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class spline_spawn : MonoBehaviour
{
    public GameObject objectPrefab;
    public Boolean destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjectRoutine()
    {
        while (true)
        {
            // Calculate a random spawn interval between 3 and 9 seconds
            float spawnInterval = UnityEngine.Random.Range(3f, 9f);

            // Instantiate the object at the current position
            GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
            SplineContainer splineContainer = gameObject.GetComponent<SplineContainer>();
            SplineAnimate splineAnimate = newObject.GetComponent<SplineAnimate>();
            splineAnimate.Container = splineContainer;

            // Wait for the randomly selected interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
