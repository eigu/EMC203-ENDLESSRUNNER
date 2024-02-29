using UnityEngine;

public class FakeTransform : MonoBehaviour
{
  [SerializeField]
  protected Vector3 _fakePosition;
  public Vector3 FakePosition
  {
    get { return _fakePosition; }
    set { _fakePosition = value; }
  }

  protected virtual void Update()
  {
    AdjustPerspetive();

    if (FakePosition.z <= -CameraComponent.FocalLength)
    {
      Destroy(gameObject);
    }
  }

  protected virtual void AdjustPerspetive()
  {
    var perspective = CameraComponent.FocalLength / (CameraComponent.FocalLength + FakePosition.z);

    transform.localScale = Vector3.one * perspective;

    transform.position = new Vector2(FakePosition.x, FakePosition.y) * perspective;
  }
}
