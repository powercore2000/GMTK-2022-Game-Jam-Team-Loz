using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
