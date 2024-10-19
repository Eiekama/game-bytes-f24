using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class GateSpawn : MonoBehaviour
{
    //[SerializeField] GameObject fullGate;

    [SerializeField] GameObject playerOneBarriers;
    [SerializeField] GameObject playerTwoBarriers;
    [SerializeField] float speed;
    [SerializeField] List<GameObject> players;
    private List<Transform> startLocs;
    Dictionary<GameObject, gateObject> gates;
    [SerializeField] List<GameObject> gatePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        gates = new Dictionary<GameObject, gateObject>();

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
        gateObject gate_object = GateDataController.getGateData(1);

        gate_object.gateCount = 1;
        //try
        //{
        GameObject gate1 = Instantiate(getGatePrefab(gate_object), playerOneBarriers.transform);
        GameObject gate2 = Instantiate(getGatePrefab(gate_object), playerTwoBarriers.transform);

        GateDataController.setUpGate(gate1, gate_object);
        GateDataController.setUpGate(gate2, gate_object);

        gates.Add(gate1, gate_object);
        gates.Add(gate2, gate_object);
        //}
        //catch (IndexOutOfRangeException e)
        //{
        Debug.Log(gate_object.gateCount);
        //    e.ToString();
        //}

        yield return new WaitForSeconds(2);
        StartCoroutine(makeGate());
    }

    GameObject getGatePrefab(gateObject gate)
    {
        return gatePrefabs.ElementAt(gate.gateCount - 1);
    }
}
