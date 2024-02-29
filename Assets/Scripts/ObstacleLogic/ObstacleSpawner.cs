using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
  [SerializeField]
  private FakeTransform _prefab;
  [SerializeField]
  private List<Transform> _spawnPoints;
  [SerializeField]
  private float _spawnInterval;

  private void Start()
  {
    InvokeRepeating(nameof(Spawn), 1, _spawnInterval);
  }

  private void Spawn()
  {
    int skippedSpawnPoint = Random.Range(0, _spawnPoints.Count);

    for (int i = 0; i < _spawnPoints.Count; i++)
    {
      if (i == skippedSpawnPoint) continue;

      var spawnedObstacle = Instantiate(_prefab);

      var spawnPosition = _spawnPoints[i].position;
      spawnPosition.z = CameraComponent.FocalLength;

      spawnedObstacle.FakePosition = spawnPosition;
    }
  }
}
