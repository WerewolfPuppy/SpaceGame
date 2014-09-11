using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

  public bool Player1;
    
  public bool dead;

  public GameObject deathExplosion;

  void OnCollisionEnter (Collision colinfo) {
    if(colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall"){
      dead = true;
      Win();
    }
    if(colinfo.collider.tag == "SpaceShip")
      {
	GlobalPlayerData.draw = true;
	dead = true;
	Win();
      }
  }

  void Win()
  {
    GlobalPlayerData.gameOver = true;
    if(GlobalPlayerData.draw == false)
      {
	if (GlobalPlayerData.playerInt == 0)
	  {
	    GlobalPlayerData.winner = !Player1;
	  }
      }
    Instantiate(deathExplosion, transform.position, transform.rotation);
    Time.timeScale = 0;
    Destroy(gameObject);
  }
}
