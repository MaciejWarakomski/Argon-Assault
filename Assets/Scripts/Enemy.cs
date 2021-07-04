using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
