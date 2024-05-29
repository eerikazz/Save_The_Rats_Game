using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class playerScript : MonoBehaviour
{
    private SplineAnimate splineAnimate;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        splineAnimate = GetComponent<SplineAnimate>();
        PauseAnimation();
    }

    public void AnimationStateChange()
    {
        Debug.Log("click");

        if (isPaused == true)
        {
            PlayAnimation();
        }
        else
        {
            PauseAnimation();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }

    private void PauseAnimation()
    {
        splineAnimate.Pause();
        isPaused = true;
    }

    private void PlayAnimation()
    {
        splineAnimate.Play();
        isPaused = false;
    }
}
