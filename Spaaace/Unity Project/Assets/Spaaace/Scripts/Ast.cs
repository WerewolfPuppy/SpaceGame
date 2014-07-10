using UnityEngine;
using System.Collections;

public class Ast : MonoBehaviour {

    Vector3 MoveDir;

    public float moveSpeed;

    public Animation Death;

    public int AstLvl;

    public GameObject AstLvl4;
    public GameObject AstLvl3;
    public GameObject AstLvl2;
    public GameObject AstLvl1;
	
	void Start () {
        
        RandomDir();
    }

    void Update(){

        transform.Translate(MoveDir * moveSpeed * Time.deltaTime, Space.World);
    }   

    void RandomDir() {
        MoveDir = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), 0, transform.position.z + Random.Range(-10.0f, 10.0f)).normalized*moveSpeed;
    }


    void OnCollisionEnter(Collision colInfo){

        MoveDir = Vector3.Reflect(MoveDir.normalized, colInfo.contacts[0].normal).normalized * moveSpeed;

        MoveDir = new Vector3(MoveDir.x, 0, MoveDir.z);

        if(colInfo.collider.tag == "Missile"){
            
            if(AstLvl == 5){
              Instantiate(AstLvl4, transform.position, transform.rotation);
              Instantiate(AstLvl4, transform.position+Vector3.right, transform.rotation);
            }
                else if(AstLvl == 4){
                    Instantiate(AstLvl3, transform.position, transform.rotation);
                    Instantiate(AstLvl3, transform.position + Vector3.right, transform.rotation);
                }
                    else if (AstLvl == 3)
                    {
                        Instantiate(AstLvl2, transform.position, transform.rotation);
                        Instantiate(AstLvl2, transform.position + Vector3.right, transform.rotation);
                    }
                        else if (AstLvl == 2)
                        {
                            Instantiate(AstLvl1, transform.position, transform.rotation);
                            Instantiate(AstLvl1, transform.position + Vector3.right, transform.rotation);
                        }
        Destroy(gameObject);
        }
    }
}
