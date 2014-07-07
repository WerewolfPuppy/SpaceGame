using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public bool Player1;
    
    public bool Dead;

    public GameObject deathExplosion;

    void OnCollisionEnter (Collision colinfo) {
	    if(colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall"){
            //animation.Play("Dead");
            Dead = true;
            Win();
        }
	}

    void Win() {
        GlobalPlayerData.win = true;
        GlobalPlayerData.winner = !Player1;

        Instantiate(deathExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
