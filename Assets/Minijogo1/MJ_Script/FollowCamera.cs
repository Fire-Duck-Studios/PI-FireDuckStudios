using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        Vector3 newPos = cameraTransform.position;
        newPos.z = transform.position.z; // mantém o Z original (para não ficar na frente da câmera)
        transform.position = newPos;
    }
}
