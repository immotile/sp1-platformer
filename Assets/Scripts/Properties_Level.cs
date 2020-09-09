using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties_Level : MonoBehaviour
{

    public static int selectedLevel = 0;

    public static void selectLevel(int level)
    {
        selectedLevel = level;
    }

}
