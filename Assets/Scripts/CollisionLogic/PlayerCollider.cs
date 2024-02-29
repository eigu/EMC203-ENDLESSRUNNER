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

      if (CollisionLibrary.CheckCollision(playerCollider, c))
      {
        playerHealth.Decrease(1);
      }
    }
  }
}

