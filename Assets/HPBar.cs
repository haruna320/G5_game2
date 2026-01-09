using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour 
{
    public int maxHP = 100;
    public int countHP;
    public Slider hpSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = countHP;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("recover"))
        {
            RecoverHP(20);
            Destroy(collision.gameObject);
        }
    }
    void RecoverHP(int ammount)
    {
        countHP += ammount;
        if (countHP > maxHP)
        {
            countHP = maxHP;
        }
        hpSlider.value = countHP;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
