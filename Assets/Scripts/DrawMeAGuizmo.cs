using UnityEngine;
using System.Collections;

public class DrawMeAGuizmo : MonoBehaviour
{
    public float xSize = 1;
    public float ySize = 1;
    public float zSize = 1;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(xSize, ySize, zSize));
    }
}
