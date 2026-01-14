using System;
using UnityEngine;
using UnityEngine.UI;

public class HpGauge : MonoBehaviour
{
    public int HP = 100;
    public Slider hpSlider;
    private int maxHP;
    public Image HPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHP = HP;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Swwets")
        {
            HP++;
            Debug.Log("nowhp = " + HP);
            HPBar.fillAmount = (float)HP / maxHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
