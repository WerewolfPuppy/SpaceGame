using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool Player1;
    
    public bool Dead;

    public GameObject deathExplosion;

    void OnCollisionEnter (Collision colinfo) {
	    if(colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall"){
            Dead = true;
            Win();
        }
	}

    void Win()
    {
        if (GlobalPlayerData.astCount == 0)
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
        Time.timeScale = 0;
        Destroy(gameObject);
    }

}
