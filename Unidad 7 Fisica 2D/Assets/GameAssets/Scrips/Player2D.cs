using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public float movSpeed;
    public float jumpForce;

    public Transform groundDetector;
    public float groundDetectDist;

    Rigidbody2D rigi;
    Animator anim;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * movSpeed * Time.deltaTime * horizontal;

        //rigi.MovePosition(transform.position + Vector3.right * movSpeed * Time.deltaTime * horizontal);


        if (horizontal != 0) {
            transform.localScale = new Vector3(horizontal, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            rigi.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }



        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        anim.SetFloat("SpeedY", rigi.velocity.y);
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundDetector.position, groundDetectDist);
        foreach (Collider2D col in colliders) {
            if (col.gameObject.tag == "Ground") {
                isGrounded = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundDetector.position, groundDetectDist);
    }

}
