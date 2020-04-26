using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jump;
    Rigidbody2D rigidbody2D;
    Animator animator;
    BoxCollider2D[] collider2D;
    bool isMove;
    bool isJump;
    bool lookUp;
    bool CrouchDown;
    bool FaceRight;
    int fuck;
    enum JumpState { singleJump = 0, waitState, doubleJump, cantJump };
    JumpState jumpState;

    // Start is called before the first frame update
    void Start()
    {
        jumpState = JumpState.singleJump;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponents<BoxCollider2D>();
        FaceRight = true;
        isJump = false;
        ChangeFace();
        fuck = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void ChangeFace()
    {
        if(FaceRight)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Move()
    {
        isMove = false;
        lookUp = false;
        CrouchDown = false;
        collider2D[0].offset = Vector2.zero;
        collider2D[0].size = new Vector2(0.4f, 0.5f);

        // 方向鍵輸入
        if (Input.GetKey(Setting.Keys.KEY_LEFT))
        {
            Vector3 pos = transform.position;
            pos += new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0);
            transform.position = pos;

            isMove = true;
            if (FaceRight)
            {
                FaceRight = !FaceRight;
                ChangeFace();
            }
        }
        else if (Input.GetKey(Setting.Keys.KEY_RIGHT))
        {
            Vector3 pos = transform.position;
            pos += new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0);
            transform.position = pos;

            isMove = true;
            if (!FaceRight)
            {
                FaceRight = !FaceRight;
                ChangeFace();
            }
        }
        else if (Input.GetKey(Setting.Keys.KEY_UP))
        {
            lookUp = true;
        }
        else if (Input.GetKey(Setting.Keys.KEY_DOWN))
        {
            CrouchDown = true;
            collider2D[0].offset = new Vector2(0, -0.25f);
            collider2D[0].size = new Vector2(0.1f, 0.1f);
        }

        // 動畫控制
        if (!isJump)
        {
            animator.SetBool("Move", isMove);
            animator.SetBool("LookUp", lookUp);
            animator.SetBool("CrouchDown", CrouchDown);
        }
    }

    void Jump()
    {
        switch (jumpState)
        {
            case JumpState.singleJump:
                if (Input.GetKey(Setting.Keys.KEY_JUMP))
                {
                    fuck++;
                    jumpState++;
                    if (fuck % 2 == 0)
                        StartCoroutine(CoroutineJumping());
                }
                break;
            case JumpState.waitState:
                if (!Input.GetKey(Setting.Keys.KEY_JUMP))
                {
                    jumpState++;
                }
                break;
            case JumpState.doubleJump:
                if (Input.GetKey(Setting.Keys.KEY_JUMP))
                {
                    jumpState++;
                    StartCoroutine(CoroutineJumping());
                }
                break;
            case JumpState.cantJump:

                break;
            default:
                break;
        }
    }

    IEnumerator CoroutineJumping()
    {
        rigidbody2D.gravityScale = 0;
        int count = 0;
        rigidbody2D.velocity = Vector2.zero;
        while (count < 5 && Input.GetKey(Setting.Keys.KEY_JUMP))
        {
            rigidbody2D.AddForce(Vector2.up * jump * Mathf.Cos(count * 20 * Mathf.Deg2Rad));
            yield return new WaitForFixedUpdate();
            count++;
        }
        rigidbody2D.gravityScale = 2;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (transform.position.y > collision.transform.position.y)
                jumpState = JumpState.singleJump;
        }
        else
        {
            return;
        }
    }
}
