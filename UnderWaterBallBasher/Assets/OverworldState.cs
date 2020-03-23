using System.Collections.Generic;
using UnityEngine;

public static class OverworldState {
    public static List<GameObject> zombies = new List<GameObject>();

    public static Vector3 PlayerPos { get; set; }

    public static bool FirstStart { get; set; } = true;

    //public static GameObject Zombie0 { get; set; }

    //public static GameObject Zombie1 { get; set; }

    //public static GameObject Zombie2 { get; set; }

    //public static GameObject Zombie3 { get; set; }
}
