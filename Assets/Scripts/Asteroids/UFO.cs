using UnityEngine;

public class UFO : MonoBehaviour
{
    [Header("UFO Movement")]
    public float moveSpeed;

    private Transform player;

    void Update()
    {
        // If we don't have a player yet, try to find one.
        if (player == null)
        {
            FindPlayer();
        }

        // Don't move until a player has been found.
        if (player == null)
        {
            return;
        }

        // Find direction toward the player.
        Vector3 direction = player.position - transform.position;

        direction.Normalize();

        // Move toward the player.
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void FindPlayer()
    {
        if (LevelManager.instance != null &&
            LevelManager.instance.playerController != null &&
            LevelManager.instance.playerController.pawn != null)
        {
            player = LevelManager.instance.playerController.pawn.transform;
        }
    }
}