using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour {


    void OnGUI() {
        if (GlobalPlayerData.gameOver == true)
        {
            if(GlobalPlayerData.winner && GlobalPlayerData.playerInt == 0){
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Player 1 Wins!");
            }

            if (!GlobalPlayerData.winner && GlobalPlayerData.playerInt == 0)
            {
                GUI.Box(new Rect(Screen.width/2, Screen.height/2, 100, 25), "Player 2 Wins!");
            }

            if (GlobalPlayerData.gameOver && GlobalPlayerData.playerInt != 0 && !GlobalPlayerData.win)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Player Wins!");
            }

            if (!GlobalPlayerData.gameOver && GlobalPlayerData.playerInt != 0 && GlobalPlayerData.win)
            {
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Astroids Remaining: "+GlobalPlayerData.astCount);
            }

            if (GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) + 50, 110, 25), "Play Again?")) {
                GlobalPlayerData.gameOver = false;
                Time.timeScale = 1;
                Application.LoadLevel("Lobby");
            }
        }
    }
}
