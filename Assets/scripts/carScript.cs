using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class carScript : MonoBehaviour
{
    private SplineAnimate splineAnimate;

    // materials 
    private Renderer childRenderer;
    public List<Material> materials;

    void Start()
    {
        childRenderer = GetComponentInChildren<Renderer>();
        splineAnimate = GetComponent<SplineAnimate>();

        // Check if there are materials in the list
        if (materials.Count > 0)
        {
            // Select a random material from the list
            int randomIndex = Random.Range(0, materials.Count);
            Material randomMaterial = materials[randomIndex];

            // Assign the random material to the GameObject's Renderer
            childRenderer.material = randomMaterial;
        }
        else
        {
            Debug.LogWarning("No materials!!!");
        }
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
