using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameUtils
{
    /// <summary>
    /// Calculates the unit direction from the closest enemy to the player by comparing between the player and the list of enemies.
    /// </summary>
    public static Vector2 ClosestEnemyToPlayerDir(Player player)
    {
        List<Enemy> enemies = Object.FindObjectsByType<Enemy>(FindObjectsInactive.Exclude).ToList();
        Vector3 playerPosition = player.transform.position;

        if (enemies.Count == 0)
        {
            return Vector2.zero;
        }

        enemies.Sort((enemy, prevEnemy) =>
        {
            return Vector2.Distance
            (
                enemy.Rigidbody.position, playerPosition) < Vector2.Distance(prevEnemy.Rigidbody.position, playerPosition
            ) 
            ? -1 
            : 1;
        });
        
        Enemy closestEnemy = enemies[0];

        return (closestEnemy.transform.position - playerPosition).normalized;
    }

    /// <summary>
    /// Calculates the unit direction from the player to the enemy.
    /// </summary>
    public static Vector2 PlayerToEnemyDir(Player player, Enemy enemy)
    {
        Vector2 position = enemy.Rigidbody.position;
        Vector2 targetPosition = player.Rigidbody.position;
        return (targetPosition - position).normalized;
    }
}
