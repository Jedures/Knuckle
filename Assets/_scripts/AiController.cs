using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;

    private void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Player != null)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Player.transform.rotation.z,
                                                transform.rotation.z);

            Vector3 direction = rb.transform.position - Player.transform.position;
            rb.AddForceAtPosition(direction.normalized, Player.transform.position);
        }
    }
}
