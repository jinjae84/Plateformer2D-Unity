using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMover : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform[] movePosition;
    public float speed = 2f;
    private bool ismoving = false;
    public int moveIndex = 0;
    private bool movingFoward = true;
    private Transform playerTransform;
    private Vector3 lastPlatformPosition;
    private Vector3 startPosition;
    public float pauseDuration = 1f;
    private bool isPaused = false;

    // Start is called before the first frame update

    private void Start()
    {
        lastPlatformPosition = transform.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ismoving)
        {
            Moveplatform();
        }
        else
        {
            ReturnToStartPosition();
        }
        if(playerTransform != null)
        {
            Vector3 platformMovement = transform.position - lastPlatformPosition;
            playerTransform.position += platformMovement;
        }

        lastPlatformPosition = transform.position;
    }

    

    private void Moveplatform()
    {
        if (movePosition.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, movePosition[moveIndex].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePosition[moveIndex].position) < 0.1f )
        {
            if (movingFoward)
            {
                moveIndex++;
                if(moveIndex >= movePosition.Length)
                {
                    moveIndex = movePosition.Length - 1;
                    movingFoward = false;
                }
            }
            else
            {
                moveIndex--;
                if(moveIndex < 0)
                {
                    moveIndex = 0;
                    movingFoward = true;
                }
            }

            StartCoroutine(pauseBeforeMoving());
        }
    }

    private void ReturnToStartPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ismoving = true;
            playerTransform = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ismoving = false;
            playerTransform = null;
        }
    }

    private IEnumerator pauseBeforeMoving()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        isPaused = false;
    }
}
