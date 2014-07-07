using UnityEngine;
using System.Collections;

public class WinScreen : MonoBehaviour {

    public bool PlayerWin1;

    public Vector3 WinFreeze;

    void OnGUI() {
        if(GlobalPlayerData.win == true){
            WinFreeze = new Vector3(0, 0, 0);
            GlobalPlayerData.playerInt = 0;
           if(PlayerWin1 == true){
               GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "Player 1 Wins!");
           }

           if (PlayerWin1 == false)
           {
               GUI.Box(new Rect(Screen.width/2, Screen.height/2, 100, 100), "Player 2 Wins!");
           }

           if (GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) + 50, 110, 25), "Play Again?")) {
               Time.timeScale = 1;
               Application.LoadLevel("Lobby");
           }
        }
    }
}
