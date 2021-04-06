
using UnityEngine;

public static class CurrentPlayer
{
    private static int playerPos;

    static CurrentPlayer()
    {
        playerPos = 0;
    }

    public static void ChangePosition(int pos)
    {
        playerPos = pos;
    }

    public static int GetPosition()
    {
        // Debug.Log("PlayerPos = " + playerPos);
        return playerPos;
    }
}
