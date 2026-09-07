using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{

    void Start()
    {
        MaxHealth = Health;
        OnDeath = () =>
        {
            SceneManager.LoadScene("Main");
        };
    }

    void Update()
    {
        
    }
}
