using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace FlappyBird {

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent onGameOver, onIncreaseScore;
        public bool isGameOver { get; private set; }
        public int scoreCount { get; private set; }

        public static GameManager Instance {
            get; private set;
        }
        private void Awake() {

            if (Instance != null) DestroyImmediate(gameObject);
            else Instance = this;
        }
        public void GameOver() {
            isGameOver = true;
            if (onGameOver != null) onGameOver.Invoke();
        }

        public void IncreaseScore() {
            scoreCount++;
            if (onIncreaseScore != null) onIncreaseScore.Invoke();
        }

        //Buttons
        public void OnMenuButton() {
            SceneManager.LoadScene("Menu");
        }
        public void OnPlayButton() {
            SceneManager.LoadScene("App");
        }



    }
}


