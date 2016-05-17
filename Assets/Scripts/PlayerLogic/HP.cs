using UnityEngine;
using System.Collections;

public static class HP {

    public static int health = 5;
    

    public static void damage(int change)
    {
        health -= change;
        if(health <= 0)
        {
            health = 0;
            Dieded();
        }
    }

    public static void recover(int change)
    {
        health += change;
        if (health >= 5)
        {
            health = 5;
        }
    }

    public static void resethealth()
    {
        health = 5;
    }

    public static void Dieded()
    {
        Debug.Log("You Lose");
    }
}
