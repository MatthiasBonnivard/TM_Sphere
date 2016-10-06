using UnityEngine;
using System.Collections;

public class ButtonController : GUIManager {
    public bool pushed = false;
    private GameObject actionnedByButton;
    public float soloButtonTimer;
    private int movmtDuration;
    public enum ButtonActionType
    {
        BRIDGE,
        UP_BLOCK,
        DOOR
    }
    public ButtonActionType actionType;
    // some seconds lasting button effect in solo mode to add
    public GameMode gameMode = GameMode.SOLO;

	void Start () {
        GetComponent<Renderer>().material.color = white;
        actionnedByButton = GameObject.Find("ActionnedByButton");
        actionnedByButton.GetComponent<Renderer>().material.color = white;
        soloButtonTimer = 0f;
        movmtDuration = 0;
	}
	
	void Update () {
        if (movmtDuration == 100)
        {
            pushed = false;
            // ActionTriggered();
            movmtDuration = 0;
        }

        if (pushed)
        {
            soloButtonTimer += Time.deltaTime;
            if (actionType == ButtonActionType.BRIDGE)
                actionnedByButton.transform.position += new Vector3(0.08f, 0, 0);
            else if (actionType == ButtonActionType.UP_BLOCK)
                actionnedByButton.transform.position +=
                    new Vector3(0, 0.01f, 0);
            else if (actionType == ButtonActionType.DOOR)
                actionnedByButton.transform.position -= new Vector3(0, 0.02f, 0);
            movmtDuration++;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(pushed){
            transform.position += new Vector3(0, 0.1f, 0);
        }
        else
        {
            transform.position -= new Vector3(0, 0.1f, 0);
            //ActionTriggered();
            pushed = true;
        }
    }

    void ActionTriggered()
    {
        if (gameMode == GameMode.SOLO)
        {
            if (pushed)
            {
                if (actionType == ButtonActionType.BRIDGE)
                    actionnedByButton.transform.position -= new Vector3(8f, 0, 0);
                else if (actionType == ButtonActionType.UP_BLOCK)
                    actionnedByButton.transform.position -= new Vector3(0, 1f, 0);
                else if (actionType == ButtonActionType.DOOR)
                    actionnedByButton.transform.position += new Vector3(0, 2f, 0);
            }
            else
            {
                if (actionType == ButtonActionType.BRIDGE)
                    actionnedByButton.transform.position += new Vector3(8f, 0, 0);
                else if (actionType == ButtonActionType.UP_BLOCK)
                    actionnedByButton.transform.position += new Vector3(0, 1f, 0);
                else if (actionType == ButtonActionType.DOOR)
                    actionnedByButton.transform.position -= new Vector3(0, 2f, 0);
            }
        }
        else if (gameMode == GameMode.MULTI)
        {
            ///TODO
        }

    }
}
