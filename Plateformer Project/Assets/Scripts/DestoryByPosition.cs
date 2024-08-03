using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByPosition : MonoBehaviour
{
    private void LateUpdate()
    {
        if (transform.position.x < Constrants.min.x ||
            transform.position.x > Constrants.max.x ||
            transform.position.y < Constrants.min.y ||
            transform.position.y > Constrants.max.x)
        {
            Destroy(gameObject);
        }
    }
}
