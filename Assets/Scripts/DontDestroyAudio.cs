using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    public bool destroyOnSceneRemoval = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Destroy(gameObject);
        }
    }
}