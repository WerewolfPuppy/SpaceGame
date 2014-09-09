using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private int buttonHeight = 50;
    private int buttonWidth = 200;

    private int boxHeight = 250;
    private int boxWidth = 250;

    private bool menuGUI;

    void Update() { 
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuGUI = !menuGUI;

            if (menuGUI)
            {
                Time.timeScale = 0;
            }
            else if (!GlobalPlayerData.gameOver && !menuGUI)
            {
                Time.timeScale = 1;
            }
        }
    }

	void OnGUI () {
        if (menuGUI) {
            GUI.Box(new Rect((Screen.width/2)-boxWidth/2, (Screen.height / 2)-boxHeight/2, boxHeight,boxWidth), "Menu");
            if (GUI.Button(new Rect((Screen.width / 2) - buttonWidth / 2, ((Screen.height / 2) - boxHeight / 2) + 25, buttonWidth, buttonHeight), "Coming Soon"))
            {
            
            }

            if (GUI.Button(new Rect(((Screen.width / 2) - buttonWidth / 2), ((Screen.height / 2) - boxHeight / 2) + 100, buttonWidth, buttonHeight), "Return to Lobby"))
            {
                Application.LoadLevel("Lobby");
            }

            if (GUI.Button(new Rect((Screen.width / 2) - buttonWidth / 2, ((Screen.height / 2) - boxHeight / 2) + 175, buttonWidth, buttonHeight), "Exit Game"))
            {
                Application.Quit();
            }
        }
	}
}
