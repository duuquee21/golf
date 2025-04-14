using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isSelected = false;
    private Rigidbody rb;
    private Hoyo currentHole;

    public float launchForce = 500f;

    private  void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //click en la bola
        if (Input.GetMouseButtonDown(0))
        {

            SelectBall();
        }

        if (isSelected && Input.GetMouseButtonDown(1))
        {
            LaunchBall();
        }
    }

    private void SelectBall()
    {
        //lanzar un raycast 

        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            if (hit.transform == transform )
            {
                isSelected= true; // seleccionar la bola

            }
        }
    }


    private void LaunchBall()
    {
        isSelected =false;

        Vector3 launchDirection = Camera.main.transform.forward;
        rb.AddForce(launchDirection * launchForce);
   
    }

    private void RayoDireccion() //funcion para mostrar un rayo en la direccion de la pelota
    {
        if (isSelected)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Camera.main.transform.forward * 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            currentHole = other.GetComponent<Hoyo>();
        }
    }
}
