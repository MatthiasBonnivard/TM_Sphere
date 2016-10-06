using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Login : GUIManager
{
    private PlayerStatistics data;

    void OnGUI()
    {
        if (DataManager.FileExist())
            data = DataManager.LoadTrailData();

        string user = "Test User";
        string passwordToEdit = "0000";

        GUI.TextField(new Rect(10, 10, 100, 20), "w " + w + " h " + h,
            25);

        // Make a background box
        GUI.Box(new Rect(w * 0.20f, h * 0.20f, w * 0.6f, h * 0.6f), "");

            if (GUI.Button(new Rect(w * 0.3f, h * 0.6f, w * 0.3f, 
                h * 0.1f),"Valider"))
            {
                PlayerInformations pi = new PlayerInformations();
                pi.SetPlayerInformations(user, passwordToEdit);
                DataManager.SaveInformationsData(pi);
                Application.LoadLevel("MainMenu");
            }
            GUI.TextField(new Rect(w * 0.3f, h * 0.30f, w * 0.15f,
                h * 0.1f),"Password", 25);
            GUI.PasswordField(new Rect(w * 0.5f, h * 0.30f, w * 0.15f,
                h * 0.1f), passwordToEdit, "*"[0], 25);
            GUI.TextField(new Rect(w * 0.3f, h * 0.45f, w * 0.15f,
                h * 0.1f), "User Name", 25);
            //GUI.InputField

    }
}
