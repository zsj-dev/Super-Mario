using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinlogic : MonoBehaviour
{    

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -1f);
    }


}
