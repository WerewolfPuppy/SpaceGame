using UnityEngine;
using System.Collections;

public class MissleHP : MonoBehaviour {

    void OnCollisionEnter(Collision colinfo)
    {
        if (colinfo.collider.tag == "Ast" || colinfo.collider.tag == "Missile" || colinfo.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
