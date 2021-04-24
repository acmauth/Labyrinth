using System.Collections.Generic;

// This class is used to compare objects of the PlayerData class
public class Comp : IComparer<PlayerData>
{
    public int Compare(PlayerData x, PlayerData y)
    {
        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        if (x.avgTime < y.avgTime)
        {
            return -1;
        }
        else if (x.avgTime > y.avgTime)
        {
            return 1;
        }
        else
        {
            if (x.score < y.score)
            {
                return -1;
            }
            else if (x.score > y.score)
            {
                return 1;
            }
            else
            {
                return CheckNames(x, y);
            }
        }
    }

    private int CheckNames(PlayerData x, PlayerData y)
    {
        int i = 0;
        int result = -10;
        bool flag = true;
        while ((i < x.username.Length || i < y.username.Length) && flag)
        {
            if (x.username[i] < y.username[i])
            {
                result = -1;
                flag = false;
            }
            else if (x.username[i] > y.username[i])
            {
                result = 1;
                flag = false;
            }
            else
            {
                i++;
            }
        }

        if (result == -10)
        {
            if (i >= x.username.Length)
            {
                result = -1;
            }
            else
            {
                result = 1;
            }
        }

        return result;
    }
}
