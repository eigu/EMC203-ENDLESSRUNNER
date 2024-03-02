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

        if (FakePosition.z <= -CameraComponent.FocalLength)
        {
            Destroy(gameObject);
        }

        if (FakePosition.z <= m_playerTransform.FakePosition.z)
        {
            var render = GetComponent<SpriteRenderer>();
            render.sortingOrder = 1;
        }
    }
}
