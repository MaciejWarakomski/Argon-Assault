using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadTimer = 1f;

    [SerializeField] PlayerControls playerControls;
    [SerializeField] ParticleSystem crashVFX;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] MeshCollider meshCollider;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        meshRenderer.enabled = false;
        playerControls.enabled = false;
        meshCollider.enabled = false;
        Invoke("ReloadLevel", loadTimer);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
