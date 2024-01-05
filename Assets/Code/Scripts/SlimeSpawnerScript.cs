using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnerScript : MonoBehaviour
{
    public float playerSpeed = 4f;

    public string horizontalAxe;

    public Rigidbody2D rb;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis(horizontalAxe);

        direction = new Vector2(horizontalMovement, 0f).normalized;

        rb.velocity = direction * playerSpeed;
    }
}
