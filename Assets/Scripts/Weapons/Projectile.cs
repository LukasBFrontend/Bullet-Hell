using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class ProjectilePayload : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Collider2D collider;
    
    public void FollowCharacter(Character target)
    {
        rigidbody.linearVelocity = Vector2.MoveTowards(transform.position, target.transform.position, projectileData.initialVelocity * Time.deltaTime);
    }
}
