using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Throwing1 : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public string throwButton;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if(Input.GetButtonDown(throwButton) && readyToThrow && totalThrows > 0)
        {
            // Debug.Log(Input.GetKeyDown(throwKey));
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Vector3 forceDirection = cam.transform.forward;
        // RaycastHit hit;

        // if(Physics.Raycast(cam.position, cam.forward, out hit, 200f)) 
        // {
        //     forceDirection = (hit.point - attackPoint.position).normalized;
        // }

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows --;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}