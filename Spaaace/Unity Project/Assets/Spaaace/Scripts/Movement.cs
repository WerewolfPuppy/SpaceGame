using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Movement : MonoBehaviour {

    float speed=5;
    float amountToMove;
    float nextFire;
    float fireRate=0.5f;

    public GameObject Spawnpoint;
    public GameObject Missile;
    public GameObject Motor;

    float force=11;

    Vector3 Point;
    Vector3 Dir;
       

    void Start() {
       
    }
        
    void Update(){
        Dir = transform.forward;
        Point=transform.position;
        amountToMove = speed * Time.deltaTime;

        //transform.rotation = P1_quad;
        //if(Button1 == pressed){
        //  transform.Translate(Dir * amountToMove, Space.World);
        //}

        GameObject Cam = GameObject.Find("Main Camera");
        WinScreen WinScript = Cam.GetComponent<WinScreen>();
        if (WinScript.Win == true)
        {
            Dir = WinScript.WinFreeze;
        }
                    
        //MAIN MOVE
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Dir * amountToMove, Space.World);
            Motor.particleEmitter.emit = true;
        }

        else
        {
            Motor.particleEmitter.emit = false;
        }

        
        if (Input.GetKey(KeyCode.A)){
            transform.RotateAround(Point, Vector3.up, -75 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)){
            transform.RotateAround(Point, Vector3.up, 75 * Time.deltaTime);
        }

        //LAUNCH MISSILE
        if(Input.GetKey(KeyCode.LeftShift) && WinScript.Win == false){
            Launch();
        }
    }

    void Launch() {
        if(Time.time >= nextFire){

            GameObject instance = Instantiate(Missile, Spawnpoint.transform.position, Spawnpoint.transform.rotation)as GameObject; 
            Vector3 pos = instance.transform.forward;    
            instance.rigidbody.AddForce(pos*force, ForceMode.Impulse);

            nextFire = Time.time + fireRate;
        }
    }
}