using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] ProjectileTargetTracker targetTracker;
    [SerializeField] SO_ProjectileData projectileData;

    public void Initialize(Character target)
    {
        switch (projectileData.arcMode)
        {
            case ProjectileArcMode.Simple:
                StartCoroutine(FollowSimpleRoutine(target));
                break;
            case ProjectileArcMode.Boomerang:
                StartCoroutine(BoomerangRoutine(target));
                break;
            case ProjectileArcMode.Bounce:
                StartCoroutine(BounceRoutine(target));
                break;
        }
    }

    IEnumerator FollowSimpleRoutine(Character target)
    {
        while (Vector2.Distance(target.transform.position, transform.position) > projectileData.targetReachedThreshold)
        {
            rigidbody.linearVelocity = Vector2.MoveTowards(transform.position, target.transform.position, projectileData.initialVelocity * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator BoomerangRoutine(Character initialTarget)
    {
        throw new NotImplementedException();
    }

    IEnumerator BounceRoutine(Character target)
    {
        throw new NotImplementedException();
    }
}
