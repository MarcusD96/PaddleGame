using System.Collections.Generic;
using UnityEngine;
using Unity;
using System.Runtime.InteropServices;

public static class GameState {

    public static Vector3 PlayerPos { get; set; } //player pos in the overworld

    public static bool FirstStart { get; set; } = true; //check if the world has been initialized yet

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

    public static int EquippedWeapon { get; set; } = 0;

    public static bool FirstReward { get; set; } = true;

    public static List<Sprite> availableRewards;

    public static bool HasShield { get; set; } = false;

    public static bool HasSlow { get; set; } = false;

    public static bool HasDodge { get; set; } = false;

    [DllImport("AgvSpdSpc", CallingConvention = CallingConvention.Cdecl)] public extern static float GetStat(int statNum); //use enums
    
    [DllImport("AgvSpdSpc", CallingConvention = CallingConvention.Cdecl)] public extern static void SetStat(int statIndex, int stat); //use enums
    
    [DllImport("AgvSpdSpc", CallingConvention = CallingConvention.Cdecl)] public extern static void DefaultStats();
}

public enum Levels {
    main,
    overworld,
    selection,
    rewards,
    zombie,
    lobster
}

public enum Stats {
    agressiveness,
    speed,
    special
}
