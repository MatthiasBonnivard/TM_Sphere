using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameMenu : GUIManager
{
    private PlayerStatistics data;

    void OnGUI()
    {
        if (DataManager.FileExist())
            data = DataManager.LoadTrailData();

        float lvlBlockW = (w * 0.5f)/ nbVal;
        float lvlBlockH = (h * 0.5f) / nbLvl;

        if (GUI.Button(new Rect(0, 0, w * 0.15f, h * 0.05f), "Go to main menu"))
        {
            Application.LoadLevel("MainMenu");
        }

        GUI.TextField(new Rect(10, 10, 100, 20), "w " + w + " h " + h, 25);

        // Make a background box
        GUI.Box(new Rect(w * 0.20f, h * 0.20f, w * 0.6f, h * 0.6f), "");
        //Title of column
        GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 0, h * 0.25f,
            lvlBlockW, lvlBlockH), "Level", 25);
        GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 1, h * 0.25f,
            lvlBlockW, lvlBlockH), "Level Time", 25);
        GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 2, h * 0.25f,
            lvlBlockW, lvlBlockH), "Reaction Time", 25);
        GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 3, h * 0.25f, 
            lvlBlockW, lvlBlockH), "Order Errors", 25);

        for (int i = 1; i < nbLvl; i++)
        {
            if (GUI.Button(new Rect(w * 0.25f + lvlBlockW * 0,
                h * 0.25f + lvlBlockH * i, lvlBlockW, lvlBlockH),
                LevelStr + " " + i))
            {
                Application.LoadLevel(LevelStr + i);
            }
            GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 1,
                h * 0.25f + lvlBlockH * i, lvlBlockW, lvlBlockH),
              "" + data.GetTotalTime(i), 25);
            GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 2,
                h * 0.25f + lvlBlockH * i, lvlBlockW, lvlBlockH),
                "" + data.GetReactionTime(i), 25);
            GUI.TextField(new Rect(w * 0.25f + lvlBlockW * 3,
                h * 0.25f + lvlBlockH * i, lvlBlockW, lvlBlockH),
                "" + data.GetOrderErrors(i), 25);
        }

    }
}
