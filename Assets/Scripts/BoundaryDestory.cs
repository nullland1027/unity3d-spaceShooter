using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit(Collider other) {
        Destroy(other.gameObject);
    }
}
