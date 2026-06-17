using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int score = 0;
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 좌우 -1 ~ 1
        float v = Input.GetAxis("Vertical");   // 상하 -1 ~ 1

        transform.Translate(h * speed * Time.deltaTime,
                            v * speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.TakeDamage(10);
        }
        else
        {
            GameManager.Instance.AddScore(1);
            Destroy(other.gameObject);  // 닿은 상대를 삭제
        }
        
    }
}