using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 FakePosition;

    private void Awake()
    {

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
