using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public GameObject MotorPart;
    public GameObject missleExplosion;


    private bool parentPlayer1;

    void Update() {
        MotorPart.particleEmitter.emit = true;
    }

    void OnCollisionEnter(Collision Hit)
    {

        #region Score
        if (Hit.collider.tag == "Ast") {
            switch(Hit.collider.name){
                case "Asteroid 05":
                    GlobalPlayerData.highScore = GlobalPlayerData.highScore + 10;
                    break;

                case "Asteroid 04(Clone)":
                    GlobalPlayerData.highScore = GlobalPlayerData.highScore + 25;
                    break;

                case "Asteroid 03(Clone)":
                    GlobalPlayerData.highScore = GlobalPlayerData.highScore + 50;
                    break;

                case "Asteroid 02(Clone)":
                    GlobalPlayerData.highScore = GlobalPlayerData.highScore + 75;
                    break;

                case "Asteroid 01(Clone)":
                    GlobalPlayerData.highScore = GlobalPlayerData.highScore + 100;
                    break;
                default:
                    break;
        
            }
        }
        #endregion

        if (Hit.collider.tag == "Wall" || Hit.collider.tag == "Ast" || Hit.collider.tag == "SpaceShip" || Hit.collider.tag == "Missile"){
            Instantiate(missleExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
