using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour {

    void OnGUI() {
        if (GlobalPlayerData.gameOver == true)
        {
            GameObject[] Asts = GameObject.FindGameObjectsWithTag("Ast");

            GlobalPlayerData.astCount = Asts.Length;

            if (GlobalPlayerData.astCount == 0)
            {
                GlobalPlayerData.win = true;
            }
            else
            {
                GlobalPlayerData.win = false;
            }

            if(GlobalPlayerData.winner && GlobalPlayerData.playerInt == 0){
                GUI.Box(new Rect(Screen.width / 2-50, Screen.height / 2 - 12.5F, 100, 25), "Player 1 Wins!");
            }

            if (!GlobalPlayerData.winner && GlobalPlayerData.playerInt == 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 12.5F, 100, 25), "Player 2 Wins!");
            }

            if (GlobalPlayerData.playerInt != 0 && GlobalPlayerData.win)
            {
                GUI.Box(new Rect(Screen.width / 2-50, Screen.height / 2-12.5F, 100, 25), "Player Wins!");
            }

            if (GlobalPlayerData.playerInt != 0 && !GlobalPlayerData.win)
            {
                GUI.Box(new Rect(Screen.width / 2-100, Screen.height / 2-12.5F, 200, 25), "Score: "+GlobalPlayerData.highScore);
            }

            if (GUI.Button(new Rect(Screen.width / 2-55, (Screen.height / 2)+12.5F, 110, 25), "Play Again?")) {
                GlobalPlayerData.gameOver = false;
                Time.timeScale = 1;
                Application.LoadLevel("Lobby");
            }
        }
    }
}
