using System.Collections.Generic;
using UnityEngine;

public static class GameState {

    public static Vector3 PlayerPos { get; set; }

    public static bool FirstStart { get; set; } = true;

    public static bool HasShield { get; set; } = false;

    public static bool HasSlow { get; set; } = false;

    public static int CurrID { get; set; }

    public static List<GameObject> zombies = new List<GameObject>();

    public static bool AllZombies() {
        bool tmp = false;
        int i = 0;
        foreach(var s in zombies) {
            i++;
            if (s != null) {
                tmp = false; //if at least one thing is still spawned, then this is not true anyways
                break;
            }
            tmp = true;
        }
        return tmp;
    }

    public static int NextLevel { get; set; }

    public static int EquippedWeapon { get; set; } = 1;

    public static bool FirstReward { get; set; } = true;

    public static List<Sprite> availableRewards;

    public static List<Sprite> earnedRewards;
}
