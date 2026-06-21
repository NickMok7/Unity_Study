using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int maxHp = 100;
    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
        Debug.Log($"게임 시작! 체력: {currentHp}");
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log($"플레이어 피격! 남은 체력: {currentHp}");

        if (currentHp <= 0)
        {
            currentHp = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("게임 오버!");
        gameObject.SetActive(false);
    }
}