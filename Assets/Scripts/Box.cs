using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    private int hp = 30;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"상자 hp: {hp}");
        if (hp <= 0)
        {
            Debug.Log("상자 파괴!");
            Destroy(gameObject);
        }
    }
}
