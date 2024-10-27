
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Victims : MonoBehaviour
{
    [SerializeField]
    private GameObject victims;
    private bool isTying = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isTying) {
            StartCoroutine(tie());
        }
    }

    IEnumerator tie() {
        //&& !Villain_Move.v_isMoving && !Villain_Move.v_isSwitching
        if(Input.GetKeyDown(KeyCode.Space) && !Villain_Move.v_isSwitching) {
            isTying = true;
            GameObject newVictim = Instantiate(victims, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
            isTying = false;
        }
    }
}
