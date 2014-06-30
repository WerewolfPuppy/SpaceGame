using UnityEngine;
using System.Collections;

public class MissleHP : MonoBehaviour {

    public GameObject missleExplosion;

    void OnCollisionEnter(Collision colinfo)
    {
        if (colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall")
        {
            Instantiate(missleExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
