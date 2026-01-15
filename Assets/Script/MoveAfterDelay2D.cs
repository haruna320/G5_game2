using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveAfterDelay2D : MonoBehaviour
{
    [SerializeField] float delay = 10f;
    [SerializeField] float speed = 5f;
    [SerializeField] Vector2 direction = Vector2.right;

    [SerializeField] float targetX = 15f;          // ← このX座標を超えたらシーン移動
    [SerializeField] string nextSceneName = "NextScene";

    bool canMove = false;

    void Start()
    {
        StartCoroutine(StartMoveAfterDelay());
    }

    IEnumerator StartMoveAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            // ★ X座標が targetX を超えたらシーン移動
            if (transform.position.x > targetX)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}