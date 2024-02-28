using UnityEngine;

public class Obstacle : MonoBehaviour
{
  [SerializeField]
  private Vector3 _fakePosition;

  public Vector3 FakePosition
  {
    get { return _fakePosition; }
    set { _fakePosition = value; }
  }

  private void Update()
  {
    AdjustPerspetive();
  }

  private void AdjustPerspetive()
  {
    var perspective = CameraComponent.FocalLength / (CameraComponent.FocalLength + FakePosition.z);

    transform.localScale = Vector3.one * perspective;

    transform.position = new Vector2(FakePosition.x, FakePosition.y) * perspective;
  }
}
