using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    public int victim_track = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (-3.74 <= transform.position.z && transform.position.z <= -2.19) {
            victim_track = 1;
        }
        if (-1.83 <= transform.position.z && transform.position.z <= 0.17) {
            victim_track = 2;
        }
        if (0.24 <= transform.position.z && transform.position.z <= 1.94) {
            victim_track = 3;
        }
        if (2.46 <= transform.position.z && transform.position.z <= 3.58) {
            victim_track = 4;
        }
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(slide());
    }
    //for speeding up to the right
    IEnumerator slide() {
        transform.position -= Trolley_Move.leftscroll * transform.right; 
        yield return new WaitForSeconds(0.01f);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag.Equals("trolley") == true) {
            Destroy(gameObject);
        }
    }
}
