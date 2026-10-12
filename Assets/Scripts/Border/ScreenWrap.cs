using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    void LateUpdate()
    {
        if (LevelManager.instance == null)
        {
            return;
        }

        Vector3 newPosition = transform.position;

        // Wrap from RIGHT to LEFT
        if (newPosition.x > LevelManager.instance.screenRight)
        {
            newPosition.x = LevelManager.instance.screenLeft;
        }

        // Wrap from LEFT to RIGHT
        else if (newPosition.x < LevelManager.instance.screenLeft)
        {
            newPosition.x = LevelManager.instance.screenRight;
        }

        // Stop at the TOP
        if (newPosition.y > LevelManager.instance.screenTop)
        {
            newPosition.y = LevelManager.instance.screenTop;
        }

        // Stop at the BOTTOM
        else if (newPosition.y < LevelManager.instance.screenBottom)
        {
            newPosition.y = LevelManager.instance.screenBottom;
        }

        transform.position = newPosition;
    }
}