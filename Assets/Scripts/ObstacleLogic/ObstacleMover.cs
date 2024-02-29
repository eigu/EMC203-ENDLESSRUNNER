using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
  [SerializeField]
  private List<ObstacleTransform> _obstacles;
  [SerializeField]
  private float _speed;

  private void Update()
  {
    PopulateObjectList();

    foreach (var obstacle in _obstacles)
    {
      Move(obstacle);
    }
  }

  private void PopulateObjectList()
  {
    _obstacles.Clear();
    _obstacles.AddRange(FindObjectsOfType<ObstacleTransform>());
  }

  private void Move(ObstacleTransform obstacle)
  {
    var movePosition = obstacle.FakePosition;
    movePosition.z -= _speed;
    obstacle.FakePosition = movePosition;
  }
}
