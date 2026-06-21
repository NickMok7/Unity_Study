using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 어디서든 통하는 전역 통로
    private int score = 0;
    public TextMeshProUGUI scoreText;  // 점수 표시를 위한 TextMeshProUGUI 컴포넌트

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }
}
