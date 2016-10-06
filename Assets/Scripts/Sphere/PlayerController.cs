using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : GUIManager {
    //PLAYER
    private Rigidbody rb;
    private TrailRenderer tr;
    public float HorizontalSpeed;
    private bool jump = false;
    //CONSTANT
    private static string canvasName = "Canvas/";
    private static string sequencesFolder = "Sequences/";
    private static float cameraZoom = 8.0f;
    //SEQUENCE
    bool[] sequence = new bool[100];
    //TODO replace this sequence with the new menu
    public int seqSize = 4;
    public int seqNb = 1;
    private float sequenceTime = 0f;
    private float reactionTime = 0f;
    private int orderError = 0;
    private bool newPickup = false;
    private string sequenceStr = "";
    //GAME STATUS
    public GameMode gameMode = GameMode.SOLO;
    public GameStep gameStep = GameStep.START_LEVEL;
    public GameObject nextToPick;

    PlayerStatistics p;

	void Start () {
        init();
	}

    void init()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<TrailRenderer>();
        //tr.material.SetColor("_TintColor", new Color(255, 255, 255));
        gameObject.GetComponent<Renderer>().material.color = blue;
        RespawnPlayer();
    }

	// Update is called once per frame
	void Update () {
        var heading = nextToPick.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        //GameObject.Find("Direction").transform.localEulerAngles =
          //  new Vector3(0f, 0f, (float)(direction.z * 360));
        if (gameStep == GameStep.START_LEVEL)
            reactionTime += Time.deltaTime;
        CameraManager();
        if (gameStep == GameStep.PARTY_ONGOING)
        {
            PlayerControl();
            sequenceTime += Time.deltaTime;
        }
        isSequenceFinished();
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Sequence"))
        {
            bool isLogicalSequence = true;
            //get collision item number
            int x = Int32.Parse(other.gameObject.transform.name);
            //check if in the sequence logic
            for (int i = 0; i < (x - 1); i++)
            {
                if (sequence[i] != true)
                {
                    other.gameObject.GetComponent<Renderer>().material.color = red;
                    isLogicalSequence = false;
                }
            }

            if (isLogicalSequence == true)
            {
                other.gameObject.GetComponent<Renderer>().material.color = green;
                sequence[x - 1] = true;
                SequencePrinter();
            }
            else
            {
                orderError++;
            }
        }
    }

    void PlayerControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * HorizontalSpeed);

        if (Input.GetKeyDown("space") && jump)
        {
            rb.AddForce(new Vector3(0, 300f, 0));
            jump = false;
        }
        else if (!jump && rb.velocity.y == 0)
            jump = true;
        else if (gameObject.transform.position.y <= -20.0f)
            RespawnPlayer();
    }

    //on start and each time a new number is picked
    void SequencePrinter()
    {
        sequenceStr = "";
        if (gameStep.Equals(GameStep.PARTY_ONGOING))
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i])
                    sequenceStr += " " + (i+1) + " ";
            }
        }
    }

    void isSequenceFinished(){
        bool isFinished = true;

        for (int i = 0; i < seqSize; i++)
        {
            if (sequence[i] == false)
                isFinished = false;
        }
        if (isFinished)
        {
            gameStep = GameStep.SEQUENCE_FINISHED;
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = false;
            }
            //Restart player sphere
            RespawnPlayer();
            ///TODO and save the data
            p = DataManager.LoadTrailData();
            p.SetPlayerStatistics(seqNb, sequenceTime, reactionTime,
                orderError);
            DataManager.SaveTrailData(p);
        }
    }

    void RespawnPlayer()
    {
        transform.position = new Vector3(0, 2f, 0);
        rb.velocity = Vector3.zero;
    }

    void CameraManager(){
        if(gameStep != GameStep.PARTY_ONGOING)
            Camera.main.orthographicSize = cameraZoom * 2;
        else
            Camera.main.orthographicSize = cameraZoom;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, w * 0.15f, h * 0.05f), "Go to menu"))
        {
            Application.LoadLevel("Menu");
        }

        if (gameStep == GameStep.SEQUENCE_FINISHED)
        {
            if (GUI.Button(new Rect(w * 0.45f, h * 0.55f, w * 0.15f, h * 0.1f), 
                "Retry"))
            {
                gameStep = GameStep.START_LEVEL;
                tr.time = 0;
            }
            if (GUI.Button(new Rect(w * 0.45f, h * 0.45f, w * 0.15f, h * 0.1f),
                "Next Level"))
            {
                Application.LoadLevel("Level" + (seqNb + 1));
            }
        }

        if (gameStep == GameStep.START_LEVEL)
        {
            if (GUI.Button(new Rect(w * 0.45f, h * 0.45f, w * 0.15f, h * 0.1f), 
                "Start Sequence"))
            {
                gameStep = GameStep.PARTY_ONGOING;
                sequenceTime = 0f;
                tr.time = 999;
            }
            GUI.TextField(new Rect(w * 0.35f, h * 0.6f, w * 0.3f, h * 0.1f),
                " Analyse the sequence for the best path !", 50);
        }
        if (gameStep == GameStep.PARTY_ONGOING)
        {
            GUI.TextField(new Rect(w * 0.15f, 0, w * 0.05f, h * 0.05f), "LVL " + seqNb, 25);
            GUI.TextField(new Rect(w * 0.2f, 0, w * 0.05f, h * 0.05f), "Size " + seqSize, 25);
            GUI.TextField(new Rect(w * 0.4f, 0, w * 0.2f, h * 0.05f), sequenceStr, 25);
        }
    }
}
