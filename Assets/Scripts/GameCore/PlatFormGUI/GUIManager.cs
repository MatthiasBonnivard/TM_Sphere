using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
    //used colors
    protected static string LevelStr = "Level";
    protected static Color red = new Color(255, 0, 0);
    protected static Color green = new Color(0, 255, 0);
    protected static Color blue = new Color(0, 0, 255);
    protected static Color yellow = new Color(125, 125, 0);
    protected static Color white = new Color(255, 255, 255);
    //general values
    protected int nbVal = 4;
    protected int nbLvl = 4;
    protected float w = Screen.width;
    protected float h = Screen.height;

    void OnGUI()
    {
        //PlayerInformations playerInformations = DataManager.LoadInformationsData();
        //GUI.TextField(new Rect(w * 0.9f, 0, w * 0.1f, h * 0.05f), 
          //  "Logged as :", 25);
        //GUI.TextField(new Rect(w * 0.9f, h * 0.05f, w * 0.1f, 
          //  h * 0.05f), "" + playerInformations.GetLogin(), 25);

    }
}
