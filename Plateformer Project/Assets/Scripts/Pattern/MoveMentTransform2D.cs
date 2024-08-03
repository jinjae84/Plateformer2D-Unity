using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMentTransform2D : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection;
    public float originSpeed;

    public void Awake()
    {
        originSpeed = moveSpeed;
    }

    public float MoveSpeed(float modify)
    {
        moveSpeed += modify;

        return moveSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }


}
