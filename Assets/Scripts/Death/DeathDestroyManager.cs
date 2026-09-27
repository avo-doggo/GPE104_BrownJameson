using UnityEngine;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemoveOnDeath;
    public override void Die()
    {
        if(GameManager.instance != null)
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null)
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
            }
        }

        Destroy(gameObject);
    }

    public override void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Update()
    {
  
    }
}

// Start is called once before the first execution of Update after the MonoBehaviour is created
