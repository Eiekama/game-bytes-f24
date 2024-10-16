using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GateSpawn : MonoBehaviour
{
    [SerializeField] GameObject fullGate;

    [SerializeField] GameObject playerOneBarriers;
    [SerializeField] float speed;
    [SerializeField] List<Transform> startLocs;
    Dictionary<GameObject, gateObject> gates;

    // Start is called before the first frame update
    void Start()
    {
        gates = new Dictionary<GameObject, gateObject>();
        startLocs = new List<Transform>();

        Instantiate(fullGate, playerOneBarriers.transform);
        StartCoroutine(makeGate());
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerOneBarriers.transform.childCount; i++)
        {
            GameObject Go = playerOneBarriers.transform.GetChild(i).gameObject;
            Go.transform.position -= new Vector3(0, 0, speed*1);
        }
    }

    IEnumerator makeGate()
    {
        //Debug.Log(startLocs.ElementAt(0).transform.position);
        GameObject gate = Instantiate(fullGate, playerOneBarriers.transform);
        gateObject gate_object = GateDataController.getGateData(1);
        gates.Add(gate, gate_object);
        //foreach (Transform t in  startLocs)
        //{
        //    GameObject gate = Instantiate(fullGate, t);
        //    gateObject gate_object = GateDataController.getGateData(1);
        //    gates.Add(gate, gate_object);

        //    //Instantiate(fullGate, playerOneBarriers.transform);
        //}

        //Instantiate(fullGate, startLocs.ElementAt(0));
        yield return new WaitForSeconds(2);
        StartCoroutine(makeGate());
    }
}
