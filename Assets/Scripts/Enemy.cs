using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 2f;
    private int hp = 30;
    private Transform player;   //플레이어 위치 추적용

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(player == null) return;

        // 매 프레임 플레이어 방향으로 이동
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"적 hp: {hp}");
        if(hp <= 0)
        {
            GameManager.Instance.AddScore(5);   //적 처치 = 점수 5점!
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어한테 닿으면 데미지
        if(other.CompareTag("Player"))
        {
            Debug.Log("플레이어 피격!");
        }
    }
}
