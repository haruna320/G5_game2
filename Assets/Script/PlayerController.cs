using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;         // Rigidbody2D
    public float moveSpeed = 3f;    // 移動速度
    public float jumpPower = 5f;    // ジャンプ力

    private int jumpCount = 0;      // 現在のジャンプ回数
    public int maxJumpCount = 2;    // 最大ジャンプ回数（2で二段ジャンプ）
    public int HP = 0;
    public Color Background, Value;
    
    private int MaxHP;
    public Image HPBar;
    private float GaugeAmount = 0f;
    private float MaxAmount = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HPBar = gameObject.GetComponent<Image>();
        MaxHP = HP;
    }

    void Update()
    {
        // 入力取得
        float h = Input.GetAxis("Horizontal");
        bool jumpRequest = Input.GetKeyDown(KeyCode.Space);
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
            Debug.Log("nowHP = " + HP);
            jumpCount = 0;
        }
        if (collision.collider.CompareTag("Object"))
        {
            HP++;
            Debug.Log("nowHP = "+HP);
            HPBar.fillAmount = (float)HP / MaxHP;
        }
        if (collision.collider.CompareTag("Untagged"))
        {
            HP--;
            Debug.Log("nowHP = " +HP);
            HPBar.fillAmount = (float)HP / MaxHP;
        }
    }

    public void Increase(float amount)
    {
        GaugeAmount += amount;
        // ゲージ量が最大を超えないように制限
        GaugeAmount = Mathf.Min(GaugeAmount, MaxAmount);


        if (GaugeAmount >= MaxAmount)
        {
            Debug.Log("GameOver");
        }
    }
}