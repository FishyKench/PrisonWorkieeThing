using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChangerTest : MonoBehaviour
{

    [SerializeField]
    public Material _Cop;
    public Material _InMate;
    public GameObject theObject;


    // Start is called before the first frame update
    void Start()
    {
        theObject.GetComponent<MeshRenderer>().material = _InMate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            theObject.GetComponent<MeshRenderer>().material = _Cop;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            theObject.GetComponent<MeshRenderer>().material = _InMate;
        }
    }
}
