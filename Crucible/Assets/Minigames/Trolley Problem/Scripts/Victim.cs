using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    public int victim_track = 1;
    public GameObject trolley;
    public Rigidbody trolley_rb;
    static public int stun;

    private int type;
    SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        type = (int) Random.Range(1.0f, 3.99f);
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
        //1 = magenta = loved one, 2 = yellow = victim
        if(type == 1) {
            m_SpriteRenderer.color = Color.magenta;
        }
        else {
            m_SpriteRenderer.color = Color.yellow;
        }

        stun = 0;
        trolley = GameObject.FindGameObjectWithTag("real_trolley");
        trolley_rb = trolley.GetComponent<Rigidbody>();

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
        if (transform.position.x < -7.0f) {
            MinigameController.Instance.AddScore(1,1);
            Destroy(gameObject);
        }
    }
    //for speeding up to the right
    IEnumerator slide() {
        transform.position -= Trolley_Move.leftscroll * transform.right; 
        yield return new WaitForSeconds(0.01f);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag.Equals("trolley") == true) {
            if(type == 1) {
                MinigameController.Instance.AddScore(2,6);
            }
            else {
                MinigameController.Instance.AddScore(1,3);
            }

            trolley_rb.AddForce( transform.right * -200.0f, ForceMode.Impulse);
            trolley_rb.AddForce( transform.up * 200.0f, ForceMode.Impulse);
            stun = 1;
            Destroy(gameObject);
        }
    }
}
