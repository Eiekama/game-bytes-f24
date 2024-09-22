using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawn : MonoBehaviour
{
    [SerializeField] GameObject fullGate;

    [SerializeField] GameObject playerOneBarriers;

    [SerializeField] float speed;
  

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fullGate, playerOneBarriers.transform);
        StartCoroutine(makeGate());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerOneBarriers.transform.GetChildCount(); i++)
        {
            GameObject Go = playerOneBarriers.transform.GetChild(i).gameObject;
            Go.transform.position -= new Vector3(0, 0, speed*1);
        }
    }

    IEnumerator makeGate()
    {
        Instantiate(fullGate, playerOneBarriers.transform);
        yield return new WaitForSeconds(2);
        StartCoroutine(makeGate());
    }
}
