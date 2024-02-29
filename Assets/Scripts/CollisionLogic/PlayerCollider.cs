using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerCollider : MonoBehaviour
{
  private BoxCollider playerCollider
  {
    get { return GetComponent<BoxCollider>(); }
  }

  [SerializeField]
  private HealthManager playerHealth;

  private bool hasTakenDamage = false;

  private void Update()
  {
    HandleCollision();
  }

  public void HandleCollision()
  {
    var Colliders = FindObjectsOfType<BoxCollider>();

    foreach (var c in Colliders)
    {
      if (playerCollider == c) continue;

      if (CollisionLibrary.CheckCollision(playerCollider, c)
        && !hasTakenDamage)
      {
        hasTakenDamage = true;
        playerHealth.Decrease(1);
      }

      if (!CollisionLibrary.CheckCollision(playerCollider, c)
        && hasTakenDamage)
      {
        hasTakenDamage = false;
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

