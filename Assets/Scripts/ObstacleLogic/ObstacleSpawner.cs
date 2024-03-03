using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private FakeTransform _prefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _spawnInterval;

    private bool m_hasSpawned = false;

    private void FixedUpdate()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (m_hasSpawned) return;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        m_hasSpawned = true;

        int skippedSpawnPoint = Random.Range(0, _spawnPoints.Count);

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (i == skippedSpawnPoint) continue;

            var spawnedObstacle = Instantiate(_prefab);

            var spawnPosition = _spawnPoints[i].position;
            spawnPosition.z = CameraComponent.FocalLength;

            spawnedObstacle.FakePosition = spawnPosition;
        }

        yield return new WaitForSeconds(_spawnInterval);
        m_hasSpawned = false;
    }
}
