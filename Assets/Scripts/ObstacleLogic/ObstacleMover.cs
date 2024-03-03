using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField]
    private List<ObstacleTransform> m_obstacles;
    [SerializeField]
    private float _speed;

    private void FixedUpdate()
    {
        PopulateObjectList();

        foreach (var obstacle in m_obstacles)
        {
            Move(obstacle);
        }
    }

    private void PopulateObjectList()
    {
        m_obstacles.Clear();
        m_obstacles.AddRange(FindObjectsOfType<ObstacleTransform>());
    }

    private void Move(ObstacleTransform obstacle)
    {
        var movePosition = obstacle.FakePosition;
        movePosition.z -= _speed;
        obstacle.FakePosition = movePosition;
    }
}
