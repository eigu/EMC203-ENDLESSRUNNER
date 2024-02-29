using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
  [SerializeField]
  private Transform _parent;
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

  private void Update()
  {
    Sort();
  }

  private void Spawn()
  {
    int skippedSpawnPoint = Random.Range(0, _spawnPoints.Count);

    for (int i = 0; i < _spawnPoints.Count; i++)
    {
      if (i == skippedSpawnPoint) continue;

      var spawnedObstacle = Instantiate(_prefab, _parent);

      var spawnPosition = _spawnPoints[i].position;
      spawnPosition.z = CameraComponent.FocalLength;

      spawnedObstacle.FakePosition = spawnPosition;
    }
  }

  private void Sort()
  {
    List<Transform> children = new List<Transform>();
    foreach (Transform child in _parent)
    {
      children.Add(child);
    }

    children.OrderBy(a => a.GetComponent<FakeTransform>().FakePosition.z);

    for (int i = 0; i < children.Count; i++)
    {
      children[i].SetSiblingIndex(i);
    }
  }
}
