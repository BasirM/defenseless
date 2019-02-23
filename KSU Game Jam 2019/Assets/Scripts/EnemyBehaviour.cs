using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Animator anim;
    private Rigidbody2D rb2D;
    private GameObject player;
    public Transform[] patrolPoints;
    private Transform currentPoint;
    private int currentPointIndex = 0;
    private SpriteRenderer spriteRenderer;
    private const float PATROLSPEED = 2f;
    private const float CHASESPEED = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = patrolPoints[currentPointIndex].transform.position;

        Patrol();
    
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].transform.position, PATROLSPEED * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].transform.position)
            currentPointIndex += 1;
        if (currentPointIndex == patrolPoints.Length)
            currentPointIndex = 0;
    }

    void Chase()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("wdwdwdw");
            transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, CHASESPEED * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Wait(5));
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].transform.position, PATROLSPEED * Time.deltaTime);
        }
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
