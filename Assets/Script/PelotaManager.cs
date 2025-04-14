using UnityEngine;

public class PelotaManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pelotas; // Array de las pelotas disponibles
    [SerializeField] private Transform spawnPoint; // Punto inicial de aparición de la pelota

    private GameObject currentBall; // Referencia a la pelota actual
    private int currentIndex = 0; // Índice de la pelota seleccionada

    void Start()
    {
        // Crear la primera pelota al inicio del juego
        CambiarPelota(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarPelotaSiguiente();
        }
    }

    private void CambiarPelotaSiguiente()
    {
        currentIndex = (currentIndex + 1) % pelotas.Length; // Ciclar entre las pelotas
        CambiarPelota(currentIndex);
    }

    private void CambiarPelota(int index)
    {
        Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
        Quaternion rotation = spawnPoint ? spawnPoint.rotation : Quaternion.identity;

        if (currentBall != null)
        {
            // Guardar la posición y rotación actuales de la pelota antes de eliminarla
            position = currentBall.transform.position;
            rotation = currentBall.transform.rotation;

            Destroy(currentBall); // Eliminar la pelota actual
        }

        // Instanciar la nueva pelota en la posición especificada
        currentBall = Instantiate(pelotas[index], position, rotation);
        Debug.Log($"Pelota actual: {pelotas[index].name}");
    }
}
