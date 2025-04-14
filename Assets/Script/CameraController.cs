using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float distance = 5.0f; 
    public float rotationSpeed = 100.0f; 
    public Vector2 verticalAngleLimits = new Vector2(10f, 80f); 

    private float currentX = 0f; 
    private float currentY = 20f; 

    void LateUpdate()
    {
        if (target == null) return;

        // Rotar cámara con el mouse
        currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Limitar el ángulo vertical
        currentY = Mathf.Clamp(currentY, verticalAngleLimits.x, verticalAngleLimits.y);

        // Calcular la posición de la cámara
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = target.position + offset;

        // Apuntar la cámara hacia el objetivo
        transform.LookAt(target);
    }
}
