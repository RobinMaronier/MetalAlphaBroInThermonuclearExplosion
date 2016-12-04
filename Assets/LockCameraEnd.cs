using UnityEngine;
using System.Collections;

public class LockCameraEnd : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "LevelEnd")
        {
            transform.parent.GetComponent<CameraController>().end = true;
        }
    }
}
