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
    get { return m_transform.FakePosition.x - (m_width * .5f); }
  }
  public float MaximumX
  {
    get { return m_transform.FakePosition.x + (m_width * .5f); }
  }
  public float MinimumY
  {
    get { return m_transform.FakePosition.y - (m_height * .5f); }
  }
  public float MaximumY
  {
    get { return m_transform.FakePosition.y + (m_height * .5f); }
  }
  public float MinimumZ
  {
    get { return m_transform.FakePosition.z - (m_length * .5f); }
  }
  public float MaximumZ
  {
    get { return m_transform.FakePosition.z + (m_length * .5f); }
  }
}