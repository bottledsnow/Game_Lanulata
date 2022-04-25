using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmoo : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
