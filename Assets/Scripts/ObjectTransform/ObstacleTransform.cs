using UnityEngine;

public class ObstacleTransform : FakeTransform
{
    private PlayerTransform m_playerTransform;

    private void Start()
    {
        m_playerTransform = FindObjectOfType<PlayerTransform>();
    }

    protected override void Update()
    {
        base.Update();

        if (FakePosition.z <= -CameraComponent.FocalLength) Destroy(gameObject);

        if (FakePosition.z <= m_playerTransform.FakePosition.z)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            return;
        }

        int order = Mathf.FloorToInt(Mathf.Clamp(-FakePosition.z / 100, -3, 0));
        GetComponent<SpriteRenderer>().sortingOrder = (order);
    }
}
