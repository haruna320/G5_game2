using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour
{
    public Image HPBar;
    private float GaugeAmount = 0f;
    private float MaxAmount = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGaugeUI();
    }

    public void Increase(float amount)
    {
        GaugeAmount += amount;
        // ゲージ量が最大を超えないように制限
        GaugeAmount = Mathf.Min(GaugeAmount, MaxAmount);
        UpdateGaugeUI();


        if (GaugeAmount >= MaxAmount)
        {
            Debug.Log("GameOver");
        }
    }

    public void UpdateGaugeUI()
    {
        HPBar.fillAmount = GaugeAmount / MaxAmount;
    }

    //プレイヤーが触れるとお菓子が消える
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")){
            Destroy(this.gameObject);
            Debug.Log("nowhp = "+HPBar);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
