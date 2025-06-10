using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        Vector3 newPos = cameraTransform.position;
        newPos.z = transform.position.z; // mant�m o Z original (para n�o ficar na frente da c�mera)
        transform.position = newPos;
    }
}
