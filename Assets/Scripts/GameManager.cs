using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 어디서든 통하는 전역 통로

    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"점수: {score}");
    }
}
