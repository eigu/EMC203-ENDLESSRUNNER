using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform _parent;

    [SerializeField] private Obstacle _obstacleToSpawn;
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();

    [SerializeField] private float _speed;

    private float m_minHorizontal;
    private float m_maxHorizontal;
    private float m_minVertical;
    private float m_maxVertical;

    private void Start()
    {
        _parent = this.gameObject.transform;

        //InvokeRepeating(nameof(BeginSpawn), 1, 0.3f);
        BeginSpawn();
    }

    private void BeginSpawn()
    {
        var spawnedObstacle = Instantiate(_obstacleToSpawn, _parent);

        spawnedObstacle.FakePosition = GetRandomLocation();

        spawnedObstacle.FakePosition.z = CameraComponent.FocalLength;

        _obstacles.Add(spawnedObstacle);
    }

    private Vector3 GetRandomLocation()
    {
        var xRand = Random.Range(m_minHorizontal, m_maxHorizontal);
        var yRand = Random.Range(m_minVertical, m_maxVertical);
        return new Vector3(xRand, yRand, 0);
    }

    private void Update()
    {
        foreach (var obstacle in _obstacles)
        {
            ObstacleMover(obstacle);
        }

        transform.position = GetRandomLocation();

        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }
        
        children.OrderBy(x => x.position.z);
        
        for (int i = 0 ; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }
    }

    private void ObstacleMover(Obstacle obstacle)
    {
        obstacle.FakePosition.z -= _speed;
    }
}
