using UnityEngine;
using UnityEngine.UI;

public class HpGauge : MonoBehaviour
{
    public Slider hpSlider;
    public int maxHp = 100;
    public int minHp = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "recover")
        {
            hpSlider.value += 20;
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
