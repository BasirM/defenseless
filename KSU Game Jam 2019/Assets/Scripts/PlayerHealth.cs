using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image im1;
    public Image im2;
    public Image im3;
    public Sprite heartFull;
    public Sprite heartEmpty;
    public int health;

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 3:
                im1.sprite = heartFull;
                im2.sprite = heartFull;
                im3.sprite = heartFull;
                break;
            case 2:
                im1.sprite = heartFull;
                im2.sprite = heartFull;
                im3.sprite = heartEmpty;
                break;
            case 1:
                im1.sprite = heartFull;
                im2.sprite = heartEmpty;
                im3.sprite = heartEmpty;
                break;
            case 0:
                im1.sprite = heartEmpty;
                im2.sprite = heartEmpty;
                im3.sprite = heartEmpty;
                // TODO: gameover?
                break;
        }

    }
}
