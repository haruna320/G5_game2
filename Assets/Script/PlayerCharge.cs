using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }


    

    //プレイヤーが触れるとお菓子が消える
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")){
            Destroy(this.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
