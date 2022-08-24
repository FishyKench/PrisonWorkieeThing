using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedBoost : MonoBehaviour
{
    public Player pScript;
    public MeshRenderer tMesh;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Destroy(this.gameObject);
            tMesh.enabled = false;
            pScript.movementSpeed = 10f;
            yield return new WaitForSeconds(2);
            pScript.movementSpeed = 5f;
            Destroy(this.gameObject);
        }
    }
}
