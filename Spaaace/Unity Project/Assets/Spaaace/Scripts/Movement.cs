using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Movement : MonoBehaviour {

    private float speed=5;
    private float amountToMove;
    private float nextFire;
    private float fireRate = 0.5f;

    private string up;
    private string down;
    private string left;
    private string right;
    private string launch;

    public bool playerID;

    public GameObject Spawnpoint;
    public GameObject Missile;
    public GameObject Motor;

    private float force = 11;

    private Vector3 Point;
       

    void Start() {
       
    }
        
    void Update(){
        Point=transform.position;
        amountToMove = speed * Time.deltaTime;



        if (GlobalPlayerData.gameOver == true)
        {
            Time.timeScale = 0;
        }

        #region Controls for players
        if (playerID)
        {
            up = "UpArrow";
            left = "LeftArrow";
            right = "RightArrow";
            launch = "RightControl";
        }
        else {
            up = "W";
            left = "A";
            right = "D";
            launch = "LeftShift";
        }
        #endregion

        #region MOVEMENT
        if (Input.GetKey((KeyCode) System.Enum.Parse(typeof(KeyCode), up.ToString()))){
            transform.Translate(transform.forward * amountToMove, Space.World);
            Motor.particleEmitter.emit = true;
        }

        else
        {
            Motor.particleEmitter.emit = false;
        }


        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), left.ToString())))
        {
            transform.RotateAround(Point, Vector3.up, -75 * Time.deltaTime);
        }

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), right.ToString())))
        {
            transform.RotateAround(Point, Vector3.up, 75 * Time.deltaTime);
        }

        //LAUNCH MISSILE
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), launch.ToString())))
        {
            Launch();
        }
#endregion

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