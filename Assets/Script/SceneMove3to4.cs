using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2 : MonoBehaviour
{
    public string nextSceneName2 = "GoalScene"; // ˆÚ“®æ‚ÌƒV[ƒ“–¼

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Goal"))
        {
            SceneManager.LoadScene(nextSceneName2);
        }
    }
}