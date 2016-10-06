using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MainMenu : GUIManager
{
    private PlayerStatistics data;

    void OnGUI()
    {
        if (DataManager.FileExist())
            data = DataManager.LoadTrailData();

        string game1 = "Trail Making";
        string game2 = "Cube Builder";
        string game3 = "Stroop Run";
        string game4 = "Blocade Builder";

        float blockH = (h * 0.5f) / 5;

        GUI.TextField(new Rect(10, 10, 100, 20), "w " + w + " h " + h, 25);

        // Make a background box
        GUI.Box(new Rect(w * 0.20f, h * 0.20f, w * 0.6f, h * 0.6f), "");
        //Title of column
        GUI.TextField(new Rect(w * 0.25f, h * 0.25f,
            w * 0.1f, blockH), "Game", 25);
        GUI.TextField(new Rect(w * 0.35f, h * 0.25f,
            w * 0.2f, blockH), "Description", 25);
        GUI.TextField(new Rect(w * 0.55f, h * 0.25f,
            w * 0.1f, blockH), "Solo", 25);
        GUI.TextField(new Rect(w * 0.65f, h * 0.25f,
            w * 0.1f, blockH), "Multiplayer", 25);

        for (int i = 1; i < 5; i++)
        {
            if(i == 1){
                GUI.TextField(new Rect(w * 0.25f, h * 0.25f + h * 0.1f * i,
                    w * 0.1f, blockH), game1, 25);
                if (GUI.Button(new Rect(w * 0.55f, h * 0.25f + h * 0.1f * i,
                    w * 0.1f, blockH), "Play"))
                    Application.LoadLevel("Menu");
                GUI.TextField(new Rect(w * 0.35f, h * 0.25f + h * 0.1f * i,
                    w * 0.2f, blockH), "Make a trail making test\n through "
                       + "a sphere controlled logic game", 25);
            }
            else if (i == 2)
                GUI.TextField(new Rect(w * 0.25f, h * 0.25f + h * 0.1f * i,
                    w * 0.1f, blockH), game2, 25);
            else if (i == 3)
                GUI.TextField(new Rect(w * 0.25f, h * 0.25f + h * 0.1f * i,
                    w * 0.1f, blockH), game3, 25);
            else if (i == 4)
                GUI.TextField(new Rect(w * 0.25f, h * 0.25f + h * 0.1f * i,
                    w * 0.1f, blockH), game4, 25);
            GUI.TextField(new Rect(w * 0.65f, h * 0.25f + h * 0.1f * i,
            w * 0.1f, blockH), "TODO", 25);
        }

    }
}
