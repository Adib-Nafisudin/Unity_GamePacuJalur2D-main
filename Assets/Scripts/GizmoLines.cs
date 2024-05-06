using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoLines : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,transform.lossyScale);
    }
}
