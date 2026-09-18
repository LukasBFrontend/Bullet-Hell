using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Logic : MonoBehaviour
{
    /// <summary>
    /// The active player instance.
    /// </summary>
    public static Player Player
    {
        get
        {
            return _player;
        }
        private set
        {
            _player = value;
        }
    }

    /// <summary>
    /// Calculates the unit direction from the closest enemy to the player by comparing between the player and the list of enemies.
    /// </summary>
    public static Vector2 ClosestEnemyDir()
    {
        List<Enemy> enemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude).ToList();
        Vector3 playerPosition = _player.transform.position;

        if (enemies.Count == 0)
        {
            return Vector2.zero;
        }

        enemies.Sort((enemy, prevEnemy) =>
        {
            return Vector2.Distance
            (
                enemy.transform.position, playerPosition) < Vector2.Distance(prevEnemy.transform.position, playerPosition
            ) 
            ? -1 
            : 1;
        });
        
        Enemy closestEnemy = enemies[0];

        return (closestEnemy.transform.position - playerPosition).normalized;
    }

    static Player _player;
    void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }
}
