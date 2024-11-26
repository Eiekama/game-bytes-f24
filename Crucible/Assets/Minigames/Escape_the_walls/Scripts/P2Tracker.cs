using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Tracker : MonoBehaviour
{
    public GameObject P1;
    private float P1Distance;
    private float wallLength;

    private Quaternion orientation;

    public GameObject wall;
    public GameObject oval;
    float time;
    public static List<GameObject> ledger=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //List<Vector2> pastlocations= new List<Vector2>();
        Quaternion orientation = wall.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        time=oval.GetComponent<WallTime>().getTimer();
        time=(float)(3+.7*(7-time));
        if(Input.GetKey("e")){
            GameObject Wall = Instantiate(wall, P1.transform.position,orientation);
            StartCoroutine(waiter(time,Wall));
            ledger.Add(Wall);
            looped(P1.transform.position);       
    }
    }
    IEnumerator waiter(float f, GameObject destr){
        yield return new WaitForSeconds(f);///Change so that it dels based on length of ledger
        Destroy(destr);
        ledger.Remove(destr);
    }
    void looped(Vector3 pos){
        if(ledger.Count<35){
            return;
        }
        int num = ledger.Count;
        for(int i=0;i<(num-35);i=i+1){
            print(Vector3.Distance(pos,ledger[i].transform.position));
            if(Vector3.Distance(pos,ledger[i].transform.position)<.50){
                for(int j=i;j<num;j=j+1){
                    Destroy(ledger[i]);
                    ledger.Remove(ledger[i]);
                }
                break;
            }
        }
    }
}
