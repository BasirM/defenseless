using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    private Rigidbody2D rb2D;
    private const float PLAYERSPEED = 4f;
    private SpriteRenderer spriteRenderer;
    private GameObject[] pauseObjects;
    public List<GameObject> CollectedItems = new List<GameObject>();
    public Text scoreText;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePauseMenu();
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        float velX = 0, velY = 0;

        if (inputX != 0 && inputY != 0) // for diagonals
        {
            velX = (inputX > 0 ? .71f : -.71f); // cos(45deg)=sin(45deg)~=.71
            velY = (inputY > 0 ? .71f : -.71f);
        }
        else if (inputX != 0)
        {
            velX = (inputX > 0 ? 1f : -1f);
        }
        else if (inputY != 0)
        {
            velY = (inputY > 0 ? 1f : -1f);
        }

        rb2D.velocity = new Vector2(velX*PLAYERSPEED, velY*PLAYERSPEED);

        if (inputX > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (inputX < 0)
        {
            spriteRenderer.flipX = false;
        }

        bool moving = inputX != 0f || inputY != 0f;
        anim.SetBool("isMoving", moving);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                showPauseMenu();
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
                hidePauseMenu();
            }
        }

        List<GameObject> Items = GameObject.Find("Grid").GetComponent<CreateCollectibles>().Items;
        for (int i = 0; i < Items.Count; i++){
            double x1 = transform.position.x;
            double y1 = transform.position.y;
            double x2 = Items[i].transform.position.x;
            double y2 = Items[i].transform.position.y;
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            if (distance <= 1)
            {
                CollectedItems.Add(Items[i]);
                Destroy(GameObject.Find("Grid").GetComponent<CreateCollectibles>().Items[i]);
                Destroy(GameObject.Find("Grid").GetComponent<CreateCollectibles>().Lights[i]);
                GameObject.Find("Grid").GetComponent<CreateCollectibles>().Items.RemoveAt(i);
                GameObject.Find("Grid").GetComponent<CreateCollectibles>().Lights.RemoveAt(i);
            }
        }

        scoreText.text = "Food Collected: " + CollectedItems.Count;

    }

    void showPauseMenu()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    void hidePauseMenu()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}