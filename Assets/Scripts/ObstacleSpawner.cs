using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
  [SerializeField]
  private Transform _objectParent;
  [SerializeField]
  private Obstacle _objectPrefab;
  [SerializeField]
  private float _spawnInterval;


  private float m_minHorizontal;
  private float m_maxHorizontal;
  private float m_minVertical;
  private float m_maxVertical;

  private void Start()
  {
    _objectParent = this.gameObject.transform;

    InvokeRepeating(nameof(BeginSpawn), 1, _spawnInterval);
  }

  private void BeginSpawn()
  {
    var spawnedObstacle = Instantiate(_objectPrefab, _objectParent);

    var spawnPosition = GetRandomLocation();
    spawnPosition.z = CameraComponent.FocalLength;

    spawnedObstacle.FakePosition = spawnPosition;
  }

  private void GetScreenBounds()
  {
    
  }

  private Vector3 GetRandomLocation()
  {
    var xRand = Random.Range(m_minHorizontal, m_maxHorizontal);
    var yRand = Random.Range(m_minVertical, m_maxVertical);
    return new Vector3(xRand, yRand, 0);
  }
}
