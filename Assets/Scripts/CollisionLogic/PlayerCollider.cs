using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollision))]
public class PlayerCollider : MonoBehaviour
{
    private PlayerStat playerStat
    {
        get { return GetComponent<PlayerStat>(); }
    }

    private BoxCollision m_playerCollider
    {
        get { return GetComponent<BoxCollision>(); }
    }

    private void Update()
    {
        HandleCollision();
    }

    public void HandleCollision()
    {
        var Colliders = FindObjectsOfType<BoxCollision>();

        foreach (var c in Colliders)
        {
            if (m_playerCollider == c) continue;

            if (CollisionLibrary.CheckCollision(m_playerCollider, c))
            {
                playerStat.Damage(-1);
                Destroy(c.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        var Colliders = FindObjectsOfType<Shape>();
        foreach (var c in Colliders)
        {
            c.DrawCollider();
        }
    }
}

