using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class main : MonoBehaviour
{
    // game settings & configuration
    public int roadAmount = 2;
    public int playerLives = 3;

    // game objects references
    public GameObject roadGameObject;
    public GameObject playerGameObject;
    public GameObject mainCamera;
    public TextMeshProUGUI pointsText;

    // needed assets for the game objects
    public GameObject roadAsset;

    // extras
    public string tagToCount = "Player";
    private int points = 0;
    private SplineContainer playerSplineContainer;

    void Start()
    {
        BoxCollider goalCollider = GetComponent<BoxCollider>();
        int goalOffset = roadAmount * 4;

        // Get the SplineContainer component from the playerGameObject
        playerSplineContainer = playerGameObject.GetComponentInChildren<SplineContainer>();

        // Get the last knot (second knot in this case, index 1)
        var lastKnot = playerSplineContainer.Spline.ToArray()[1];
        float lastKnotOffset = (goalOffset + 4.0f) - 0.5f;

        // Create a new position vector with the desired z offset
        Vector3 lastKnotTargetPosition = new Vector3(lastKnot.Position.x, lastKnot.Position.y, lastKnotOffset);

        // Transform the new position to the local space of the spline container
        lastKnot.Position = playerSplineContainer.transform.InverseTransformPoint(lastKnotTargetPosition);

        // Set the modified last knot back to the spline
        playerSplineContainer.Spline.SetKnot(1, lastKnot);

        // spawn position for the road, this will be changed with each iteration to create distance between car spawns
        Vector3 spawnPosition = transform.position;
        Vector3 playerSpawnPosition = new Vector3(24.0f, 0f, -4.0f);
        Vector3 goalSpawnPosition = new Vector3(24.0f, 0f, goalOffset);

        goalCollider.center = goalSpawnPosition;

        InstantiateObjects(roadAmount, roadGameObject, spawnPosition, new Vector3(0, 0, 4.0f));
        InstantiateObjects(playerLives, playerGameObject, playerSpawnPosition, new Vector3(2.0f, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        int count = CountGameObjectsWithTag(tagToCount);
        
        if (count <= 0)
        {
            PlayerPrefs.SetInt("PlayerPoints", points);
            PlayerPrefs.Save();
            SceneManager.LoadScene("start_ui");
        }
    }

    // counts how many players there are left in the game
    int CountGameObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        return objectsWithTag.Length;
    }

    // if the player colides with the box xolider at the end it gives points
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            points += 10;
            pointsText.text = "Points: " + points.ToString();
        }
    }

    // For loops to spawn objects with offsets
    void InstantiateObjects(int amount, GameObject gameObjectToInstantiate, Vector3 startPosition, Vector3 positionIncrement)
    {
        Vector3 currentPosition = startPosition;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(gameObjectToInstantiate, currentPosition, transform.rotation);
            currentPosition += positionIncrement;
        }
    }
}
