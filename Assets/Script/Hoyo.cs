using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoyo : MonoBehaviour
{
    private Transform nextHoleSpawn;

    private int playerScore = 0;
    private bool BallInHole = false;
    public Transform nextHoleSpawnPoint; // aparición del siguiente hoyo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !BallInHole)
        {
            BallInHole=true;
            Debug.Log("Ha entrado la Bola");
            HandleBallInHole(other.gameObject);

        }
    }

    private void HandleBallInHole(GameObject ball)
    {
        Debug.Log("Numero de tiradas: " + playerScore);


        //reiniciar la bola en el proximo hoyo

        if (nextHoleSpawnPoint != null)
        {
            ball.transform.position = nextHoleSpawnPoint.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;  //parar la b ola

        }
        else
        {
            Debug.Log("Juego Terminado");
        }

        //reiniciar para el siguiente hoyo

        BallInHole = false;
        playerScore = 0;
    }

    public void IncrementPlayerScore()
    {
        playerScore++;
    }
}

