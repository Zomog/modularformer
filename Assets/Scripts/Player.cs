using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rigid;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded = false;

    public Transform groundCheck;

    [SerializeField]
    private float jumpForce;

    private bool facingRight;

    private float horizontal;

    private bool canJump;

    Transform playerBody;

    public Transform arm;

	void Start () {

        facingRight = true;
        rigid = GetComponent<Rigidbody2D>();
        playerBody = transform.Find("Body");

	}
	
    void FixedUpdate() {






        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        Movement(horizontal, canJump);
    }
    void Update()
    {
       
        horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);
        CheckJumpCondition();

    }

    void CheckJumpCondition()
    {
        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            canJump = true;
            isGrounded = false;
        }
        else
            canJump = false;
    }

    private void Movement(float horizontal, bool canJump)
    {
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);

        if (canJump)
        {
            canJump = false;
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    private void Flip(float horizontal)
    {

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {

            facingRight = !facingRight;

            Vector3 scale = playerBody.localScale;

            scale.x *= -1;

            playerBody.localScale = scale;

            if(!facingRight)
            {
				arm.transform.position = new Vector2((float)(transform.position.x + 0.2), (float)(transform.position.y + 0.608));
            } else
            {
				arm.transform.position = new Vector2((float)(transform.position.x - 0.17), (float)(transform.position.y + 0.608));
            }
        }

    }
}
