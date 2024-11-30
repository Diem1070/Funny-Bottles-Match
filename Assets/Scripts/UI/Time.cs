using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timeText;
    public Text movesText;
    public Text bottlesMatchedText;

    private float gameTime = 0f;

    void Update()
    {
        // update time
        gameTime += Time.deltaTime;
        UpdateTimeUI();
    }

    public void UpdateMoves(int moves)
    {
        movesText.text = "Moves: " + moves.ToString();
    }

    public void UpdateBottlesMatched(int bottlesMatched)
    {
        bottlesMatchedText.text = "Match: " + bottlesMatched.ToString();
    }

    private void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        int seconds = Mathf.FloorToInt(gameTime % 60F);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
