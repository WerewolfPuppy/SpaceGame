using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Movement2 : MonoBehaviour
{

    float speed = 5;
    float amountToMove;
    float nextFire;
    float fireRate = 0.5f;

    public GameObject Spawnpoint;
    public GameObject Missile;
    public GameObject Motor;

    float force = 11;

    Vector3 Point;
    Vector3 Dir;


    void Start()
    {

    }

    void Update()
    {
        Dir = transform.forward;
        Point = transform.position;
        amountToMove = speed * Time.deltaTime;

        //transform.rotation = P2_quad;
        //if(Button2 == pressed){
        //  transform.Translate(Dir * amountToMove, Space.World);
        //}

        GameObject Cam = GameObject.Find("Main Camera");
        WinScreen WinScript = Cam.GetComponent<WinScreen>();
        if (WinScript.Win == true)
        {
            Dir = WinScript.WinFreeze;
        }
          

        //MAIN MOVE
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Dir * amountToMove, Space.World);
            Motor.particleEmitter.emit = true;
        }
        else{
            Motor.particleEmitter.emit = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(Point, Vector3.up, -75 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(Point, Vector3.up, 75 * Time.deltaTime);
        }

        //LAUNCH MISSILE
        if (Input.GetKey(KeyCode.RightControl) && WinScript.Win == false)
        {
            Launch();
        }
    }

    void Launch()
    {
        if (Time.time >= nextFire)
        {

            GameObject instance = Instantiate(Missile, Spawnpoint.transform.position, Spawnpoint.transform.rotation) as GameObject;
            Vector3 pos = instance.transform.forward;
            instance.rigidbody.AddForce(pos * force, ForceMode.Impulse);

            nextFire = Time.time + fireRate;
        }
    }
}