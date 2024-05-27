using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchSceneBtnScript : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
