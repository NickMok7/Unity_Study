using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 2f;
    private int hp = 30;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"적 hp: {hp}");
        if (hp <= 0)
        {
            GameManager.Instance.AddScore(5);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable target))
                target.TakeDamage(10);
        }
    }
}