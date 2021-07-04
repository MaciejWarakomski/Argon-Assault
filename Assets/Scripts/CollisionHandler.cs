using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadTimer = 1f;

    [SerializeField] private PlayerControls playerControls;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        playerControls.enabled = false;
        Invoke("ReloadLevel", loadTimer);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
