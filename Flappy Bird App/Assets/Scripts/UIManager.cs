using UnityEngine;
using TMPro;

namespace FlappyBird {

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText, finalScore;

        public void UpdateScore() {
            if (scoreText != null) scoreText.text = "SCORE: " + GameManager.Instance.scoreCount.ToString(); finalScore.text = scoreText.text;
        }
    }
}


