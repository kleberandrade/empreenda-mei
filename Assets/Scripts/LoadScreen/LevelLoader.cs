﻿using UnityEngine;
public class LevelLoader : MonoBehaviour
{
    public void Loadlevel()
    {
        // Alternative method showing to wait a key press to continue and using a second load scene
        LoadScreen.Instance.LoadLevel("BigLevel", true, "LoadScreen");
    }
}