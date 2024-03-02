using UnityEngine;

public class PlayerTransform : FakeTransform
{
    [SerializeField]
    private float _lerpSpeed;

    protected override void Update()
    {
        base.Update();

        if (!Input.GetButtonDown("Horizontal")) HandleMovement();
    }

    public void HandleMovement()
    {
        Vector3 nextPosition = FakePosition;
        nextPosition.x += Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = new Vector3(Mathf.Clamp(nextPosition.x, -1, 1), FakePosition.y, FakePosition.z);
        FakePosition = Vector3.Lerp(FakePosition, newPosition, Time.deltaTime * _lerpSpeed);
    }
}
