public static class CollisionLibrary
{
  public static bool CheckCollision(BoxCollision boxA, BoxCollision boxB)
  {
    return DidCollide(boxA, boxB);
  }

  public static bool DidCollide(BoxCollision boxA, BoxCollision boxB)
  {
    return BoxCheck(boxA.MinimumX, boxA.MaximumX, boxB.MinimumX, boxB.MaximumX)
        && BoxCheck(boxA.MinimumY, boxA.MaximumY, boxB.MinimumY, boxB.MaximumY)
        && BoxCheck(boxA.MinimumZ, boxA.MaximumZ, boxB.MinimumZ, boxB.MaximumZ);
  }

  private static bool BoxCheck(float minA, float maxA, float minB, float maxB)
  {
    return maxA >= minB
        && minA <= maxB;
  }
}