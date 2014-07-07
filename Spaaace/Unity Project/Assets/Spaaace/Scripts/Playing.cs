using UnityEngine;
using System.Collections;

public class Playing : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public GameObject player1NotPlaying;
    public GameObject player1Playing;

    public GameObject player2NotPlaying;
    public GameObject player2Playing;

	// Use this for initialization
	void Start () {
        player1.transform.position = player1NotPlaying.transform.position;
        player2.transform.position = player2NotPlaying.transform.position;

        Time.timeScale = 1;

        GlobalPlayerData.gameOver = false;
        GlobalPlayerData.winner = false;
        GlobalPlayerData.playerInt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //PLAYER 1 SELECTION
	    if(Input.GetKeyDown(KeyCode.A)){
            if (player1.transform.position != player1NotPlaying.transform.position)
            {
                player1.transform.position = player1NotPlaying.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (player1.transform.position != player1Playing.transform.position)
            {
                player1.transform.position = player1Playing.transform.position;
            }
        }

        //PLAYER 2 SELECTION
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (player2.transform.position != player2NotPlaying.transform.position)
            {
                player2.transform.position = player2NotPlaying.transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (player2.transform.position != player2Playing.transform.position)
            {
                player2.transform.position = player2Playing.transform.position;
            }
        }
	}

    void OnGUI() {

        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 125, 25), "Press Enter to Play!");

        if(Input.GetKeyDown(KeyCode.Return)){
            DetectSelection();
        }
    }

    void DetectSelection() { 
        if((player1.transform.position == player1Playing.transform.position) && (player2.transform.position == player2NotPlaying.transform.position)){
            GlobalPlayerData.playerInt = 1;
            Application.LoadLevel("1Players");
        }

        if ((player1.transform.position == player1NotPlaying.transform.position) && (player2.transform.position == player2Playing.transform.position))
        {
            GlobalPlayerData.playerInt = 2;
            Application.LoadLevel("1Players");
        }

        if ((player1.transform.position == player1Playing.transform.position) && (player2.transform.position == player2Playing.transform.position))
        {
            GlobalPlayerData.playerInt = 0;
            Application.LoadLevel("2Players");
        }

        if ((player1.transform.position == player1NotPlaying.transform.position) && (player2.transform.position == player2NotPlaying.transform.position))
        {}

    }
}

public static class GlobalPlayerData {
    public static int playerInt = 0;
    public static bool gameOver = false;
    public static bool winner;
    public static bool win;
    public static int astCount;
}
