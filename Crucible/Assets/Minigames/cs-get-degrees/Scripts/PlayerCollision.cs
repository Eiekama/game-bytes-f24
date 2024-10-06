using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    List<GameObject> players = new List<GameObject>();

    [SerializeField] GameObject follower;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "barrier" && !players.Contains(other.gameObject))
        {
            //AddPlayer();
            AddPlayer();
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
}
