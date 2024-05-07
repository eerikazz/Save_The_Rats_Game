using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class carSpawn : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject triggerBoxPrefab;
    private SplineContainer splineContainer;
    private BezierKnot lastKnot;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        splineContainer = gameObject.GetComponent<SplineContainer>();
        Spline spline = splineContainer.Spline;
        lastKnot = spline.Knots.Last();

        // BUG
        //
        // The triggerbox needs to spawn where the spline ends. 
        // By default the knots position is based on the splines pivot
        // Vector3 lastKnotPosition = (gameObject.transform);

        Instantiate(triggerBoxPrefab, lastKnot.Position, lastKnot.Rotation);

        StartCoroutine(SpawnObjectWithInterval());
    }

    private IEnumerator SpawnObjectWithInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
            SplineAnimate splineAnimate = newObject.GetComponent<SplineAnimate>();
            splineAnimate.Container = splineContainer;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
