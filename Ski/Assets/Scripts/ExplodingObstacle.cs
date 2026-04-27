using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    internal override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Destroy(gameObject);
    }
}
