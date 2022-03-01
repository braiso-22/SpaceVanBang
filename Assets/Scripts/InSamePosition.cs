using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSamePosition : MonoBehaviour
{
    private bool samePosition;
    public LayerMask layerMask;

    void Awake()
    {
        samePosition = Physics.CheckSphere(transform.position, 100, layerMask);
        
    }

    public bool getSamePosition()
    {
        return samePosition;
    }
}
