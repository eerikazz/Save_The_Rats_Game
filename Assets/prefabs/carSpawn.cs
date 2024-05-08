using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

public class carSpawn : MonoBehaviour
{
    public GameObject objectPrefab;
    private SplineContainer splineContainer;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        splineContainer = gameObject.GetComponent<SplineContainer>();
        StartCoroutine(SpawnObjectWithInterval());
    }

    private IEnumerator SpawnObjectWithInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        SplineAnimate splineAnimate = newObject.GetComponent<SplineAnimate>();
        splineAnimate.Container = splineContainer;
    }
}
