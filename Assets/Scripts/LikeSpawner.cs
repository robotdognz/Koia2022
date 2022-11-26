using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikeSpawner : MonoBehaviour
{
    [SerializeField] GameObject likeObject;
    [SerializeField] float spawnRadius = 40;

    [SerializeField] float spawnTimeMin = 0.1f;
    [SerializeField] float spawnTimeMax = 0.3f;
    float currentSpawnTime = 0;
    float time = 0;

    public void SpawnNewLike()
    {
        // choose random spawn point
        Vector2 spawnPoint = Random.insideUnitCircle.normalized;
        // prevent center spawn edge case
        while (spawnPoint == Vector2.zero)
        {
            spawnPoint = Random.insideUnitCircle.normalized;
        }
        // create 'like' object
        GameObject newLike = Instantiate(likeObject, transform.position + (Vector3)spawnPoint * spawnRadius, Quaternion.identity);
        // make movement direction and apply it to 'like' object
        Vector2 spawnMovement = (-spawnPoint) + (Random.insideUnitCircle).normalized * 0.2f;
        newLike.GetComponent<Like>().SetMovementDirection(spawnMovement);
    }

    void FixedUpdate()
    {
        // spawn 'like' at random intervals
        time += Time.fixedDeltaTime;
        if (time >= currentSpawnTime)
        {
            SpawnNewLike();
            currentSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            time = 0;
        }
    }
}
