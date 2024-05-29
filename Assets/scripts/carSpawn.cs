using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarSpawn : MonoBehaviour
{
    public List<GameObject> cars;
    private SplineContainer splineContainer;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if (cars.Count == 0)
        {
            Debug.LogWarning("No cars in the list!");
            return;
        }

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
        // Select a random car from the list for each spawn
        int randomIndex = Random.Range(0, cars.Count);
        GameObject objectPrefab = cars[randomIndex];

        GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        SplineAnimate splineAnimate = newObject.GetComponent<SplineAnimate>();
        splineAnimate.Container = splineContainer;
    }
}
