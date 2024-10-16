using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GateSpawn : MonoBehaviour
{
    [SerializeField] GameObject fullGate;

    [SerializeField] GameObject playerOneBarriers;
    [SerializeField] GameObject playerTwoBarriers;
    [SerializeField] float speed;
    [SerializeField] List<GameObject> players;
    private List<Transform> startLocs;
    Dictionary<GameObject, gateObject> gates;

    // Start is called before the first frame update
    void Start()
    {
        gates = new Dictionary<GameObject, gateObject>();

        //Instantiate(fullGate, playerOneBarriers.transform);
        StartCoroutine(makeGate());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < playerOneBarriers.transform.childCount; i++)
        {
            GameObject Go1 = playerOneBarriers.transform.GetChild(i).gameObject;
            GameObject Go2 = playerTwoBarriers.transform.GetChild(i).gameObject;

            Go1.transform.position -= new Vector3(0, 0, speed*1);
            Go2.transform.position -= new Vector3(0, 0, speed * 1);

        }
    }

    IEnumerator makeGate()
    {
        Debug.Log(players.ElementAt(0).transform);
        //Transform gate0 = playerOneBarriers.transform;

        GameObject gate1 = Instantiate(fullGate, playerOneBarriers.transform);
        GameObject gate2 = Instantiate(fullGate, playerTwoBarriers.transform);
        gateObject gate_object = GateDataController.getGateData(1);
        //gates.Add(gate1, gate_object);
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
