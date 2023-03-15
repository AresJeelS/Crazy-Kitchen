using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Move
    {
        LookAt,
        LookAtInvereted,
        CameraForward,
        CameraForwardInverted
    }

    [SerializeField] private Move mode;

    private void LateUpdate()
    {
        switch (mode)
        {
            case Move.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Move.LookAtInvereted:
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Move.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Move.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}
