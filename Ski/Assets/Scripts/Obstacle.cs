using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    internal virtual void OnCollision(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Player collided with" + name);
        }
        OnPlayerHit();
    }
}