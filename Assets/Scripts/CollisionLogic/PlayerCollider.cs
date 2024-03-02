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

    private bool hasTakenDamage = false;

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

            if (CollisionLibrary.CheckCollision(m_playerCollider, c)
                && !hasTakenDamage)
            {
                hasTakenDamage = true;
                playerStat.DecreaseHP(1);

                StartCoroutine(ResetDamageFlag(.25f));
            }
        }
    }

    private IEnumerator ResetDamageFlag(float duration)
    {
        yield return new WaitForSeconds(duration);
        hasTakenDamage = false;
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

