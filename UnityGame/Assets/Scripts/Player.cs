using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    public float checkGroundRadius;
    public bool grounded;


    public Transform checkGround;
    public LayerMask isGround;


    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, checkGroundRadius, isGround);

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            _rb.velocity = new Vector3(speed, _rb.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            _rb.velocity = new Vector3(-speed, _rb.velocity.y, 0f);
        }
        else
        {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, jump, 0f);
        }
    }
}