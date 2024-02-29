using UnityEngine;

public class BoxCollider : Shape
{
  private float m_width
  {
    get { return transform.localScale.x; }
  }
  private float m_height
  {
    get { return transform.localScale.y; }
  }
  private float m_length
  {
    get { return transform.localScale.z; }
  }

  public float MinimumX
  {
    get { return transform.position.x - (m_width * .5f); }
  }
  public float MaximumX
  {
    get { return transform.position.x + (m_width * .5f); }
  }
  public float MinimumY
  {
    get { return transform.position.y - (m_height * .5f); }
  }
  public float MaximumY
  {
    get { return transform.position.y + (m_height * .5f); }
  }
  public float MinimumZ
  {
    get { return m_transform.FakePosition.z - (m_length * .5f); }
  }
  public float MaximumZ
  {
    get { return m_transform.FakePosition.z + (m_length * .5f); }
  }

  public Vector2 point1 => new Vector3(MinimumX, MinimumY);
  public Vector2 point2 => new Vector3(MinimumX, MaximumY);
  public Vector2 point3 => new Vector3(MaximumX, MaximumY);
  public Vector2 point4 => new Vector3(MaximumX, MinimumY);

  public override void DrawCollider()
  {
      base.DrawCollider();

      var VectorArray = new Vector2[] { point1, point2, point3, point4 };

      for (int i = 0; i < VectorArray.Length; i++)
      {
          var v = VectorArray[i];
          var v2 = VectorArray[(i + 1) % VectorArray.Length];
          Gizmos.DrawLine(v, v2);
      }
  }
}