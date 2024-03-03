using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    private int phase = 0;
    private float speedMultiplier = 1;
    private float baseSpeed;
    [SerializeField] PlayerController player;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        baseSpeed = player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
        player.speed = baseSpeed * speedMultiplier;

        if (Score > 140 && phase == 3)
        {
            speedMultiplier = 1.8f;
            phase++;
            return;
        }
        if (Score > 70 && phase == 2)
        {
            speedMultiplier = 1.5f;
            phase++;
            return;
        }
        if (Score > 50 && phase == 1)
        {
            speedMultiplier = 1.25f;
            phase++;
            return;
        }
        if (Score > 20 && phase == 0)
        {
            speedMultiplier = 1.1f;
            phase++;
            return;
        }
    }
}
