using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private GameObject player;
    private float x_pos, y_pos;
    private Vector3 followPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        x_pos = player.transform.position.x;
        y_pos = player.transform.position.y;

        followPosition = new Vector3(x_pos, y_pos, gameObject.transform.position.z);

        gameObject.transform.position = followPosition;

    }

    // Update is called once per frame
    void Update()
    {
        x_pos = player.transform.position.x;
        y_pos = player.transform.position.y;

        followPosition = new Vector3(x_pos, y_pos, gameObject.transform.position.z);

        gameObject.transform.position = followPosition;
    }
}
