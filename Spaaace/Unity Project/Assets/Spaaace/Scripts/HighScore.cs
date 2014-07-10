using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	void Update () {
        guiText.text = "High Score: "+GlobalPlayerData.highScore.ToString();
	}
}
