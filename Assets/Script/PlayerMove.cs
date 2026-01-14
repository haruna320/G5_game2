using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;         // Rigidbody2D
    public float moveSpeed = 3f;    // 移動速度
    public float jumpPower = 5f;    // ジャンプ力

    private int jumpCount = 0;      // 現在のジャンプ回数
    public int maxJumpCount = 2;    // 最大ジャンプ回数（2で二段ジャンプ）

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力取得
        float h = Input.GetAxis("Horizontal");
        bool jumpRequest = Input.GetKeyDown(KeyCode.Space);

        // ★移動処理（linearVelocity → velocity に修正）
        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);

        // 左右反転
        if (h != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(h), 1, 1);
        }

        // ★ジャンプ（最大2回）
        if (jumpRequest && jumpCount < maxJumpCount)
        {
            // 2段目の高さを安定させるためにY速度をリセット
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    // 地面に触れたらジャンプ回数リセット
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }
}