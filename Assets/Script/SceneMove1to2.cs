using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName = "GameScene2"; // ˆÚ“®æ‚ÌƒV[ƒ“–¼

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Goal"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}