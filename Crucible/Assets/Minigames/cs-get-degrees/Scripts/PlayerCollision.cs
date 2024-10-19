using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    List<GameObject> players = new List<GameObject>();
    [SerializeField] private MainController mc;
    [SerializeField] private int playerNum;

    [SerializeField] GameObject follower;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "barrier" && !players.Contains(other.gameObject))
        {
            //AddPlayer();
            AddPlayer();
            doGateEffect(other.gameObject);
            print("bazinga");
        }
    }
    private void Start()
    {
        
    }

    private void AddPlayer()
    {
        players.Add(Instantiate(follower, transform.position, transform.rotation));
    }

    private void doGateEffect(GameObject barrier)
    {
        gateData gd = barrier.GetComponent<BarrierStructure>().getGateData();
        calcualation calc = gd.calculation;
        changeData cd = GateDataController.doCalculation(mc.getFriends(playerNum), mc.getGPA(playerNum), calc);
        mc.setFriends(playerNum, cd.newPeople);
        mc.setGPA(playerNum, cd.newGpa);
    }
}
