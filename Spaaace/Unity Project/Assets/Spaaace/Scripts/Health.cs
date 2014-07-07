using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool Player1;
    
    public bool Dead;

    private int AstCount = 0;

    public GameObject deathExplosion;

    void OnCollisionEnter (Collision colinfo) {
	    if(colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall"){
            Dead = true;
            Win();
        }
	}

    void Win() {

        GameObject[] Asts = GameObject.FindGameObjectsWithTag("Ast");

        for (int i = 1; i > Asts.Length; i++) {
            foreach (GameObject element in Asts) {
                AstCount++;
            }
        }

        GlobalPlayerData.astCount = AstCount;

        if (AstCount == 0)
        {
            GlobalPlayerData.win = true;
        }
        else {
            GlobalPlayerData.win = false;
        }
       
        GlobalPlayerData.gameOver = true;

        if (GlobalPlayerData.playerInt == 0)
        {
            GlobalPlayerData.winner = !Player1;
        }

        Instantiate(deathExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
