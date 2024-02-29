using UnityEngine;

public class Shape : MonoBehaviour
{
  protected private FakeTransform m_transform
  {
    get { return GetComponent<FakeTransform>(); }
  }
}
