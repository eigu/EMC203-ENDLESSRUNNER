using System.Collections;
using UnityEngine;

public class PlayerTransform : FakeTransform
{
    [SerializeField] private float _moveDuration;

    protected override void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Horizontal")) StartCoroutine(HandleMovement());
    }

    public IEnumerator HandleMovement()
    {
        Vector3 nextPosition = FakePosition;
        nextPosition.x += Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = new Vector3(Mathf.Clamp(nextPosition.x, -1, 1), FakePosition.y, FakePosition.z);

        float elapsedTime = 0f;
        while (elapsedTime < _moveDuration)
        {
            FakePosition = Vector3.Lerp(FakePosition, newPosition, elapsedTime / _moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
