using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public GameObject MotorPart;

    void Update() {
        MotorPart.particleEmitter.emit = true;
    }

    void OnCollisionEnter(Collision Hit) { 
        if(Hit.collider.tag == "Wall" || Hit.collider.tag == "Ast" || Hit.collider.tag == "SpaceShip" || Hit.collider.tag == "Missile"){
            //Animation.Play(Boom);
            Destroy(gameObject);
        }
    }
}
