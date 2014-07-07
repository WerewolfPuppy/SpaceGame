using UnityEngine;
using System.Collections;

public class SinglePlayerSpawn : MonoBehaviour {

    public GameObject spawnPoint;

    public GameObject sShip1;
    public GameObject sShip2;

	// Use this for initialization
	void Start () {
        if (GlobalPlayerData.playerInt == 1 || GlobalPlayerData.playerInt == 0) {
            Instantiate(sShip1, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

        if (GlobalPlayerData.playerInt == 2)
        {
            Instantiate(sShip2, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
	}
}
