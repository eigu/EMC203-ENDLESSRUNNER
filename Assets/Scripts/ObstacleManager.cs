using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
  [SerializeField]
  private List<Obstacle> _obstacles = new List<Obstacle>();
  [SerializeField]
  private float _speed;

  private void Update()
  {
    PopulateObjectList();

    foreach (var obstacle in _obstacles)
    {
      ObstacleMover(obstacle);
    }
  }

  private void PopulateObjectList()
  {
    _obstacles.Clear();
    _obstacles.AddRange(FindObjectsOfType<Obstacle>());
  }

  private void ObstacleMover(Obstacle obstacle)
  {
    var movePosition = obstacle.FakePosition;
    movePosition.z -= _speed;
    obstacle.FakePosition = movePosition;
  }
}
