using UnityEngine;

namespace FlappyBird
{
    public class Bird : MonoBehaviour
    {
        private Animator myAnim;
        private SpriteRenderer myBird;
        [SerializeField] private Sprite[] birdColors;
        [SerializeField] private RuntimeAnimatorController[] birdAnim;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField, Range(0, 10)] private float speed;
        [SerializeField] private AudioSource scoreSFX, jumpSFX;

        private void Awake() {
            if (rigidbody2D == null)
                rigidbody2D = GetComponent<Rigidbody2D>();

            myBird = gameObject.GetComponent<SpriteRenderer>();
            myAnim = gameObject.GetComponent<Animator>();
        }

        private void Start() {
            //Change Bird color and animation
            myBird.sprite = birdColors[Random.Range(0, birdColors.Length)];
            if (myBird.sprite == birdColors[0]) myAnim.runtimeAnimatorController = birdAnim[0];
            else if (myBird.sprite == birdColors[1]) myAnim.runtimeAnimatorController = birdAnim[1];
            else if (myBird.sprite == birdColors[2]) myAnim.runtimeAnimatorController = birdAnim[2];
        }

        private void Update()
        {
            if (GameManager.Instance.isGameOver) return;


#if UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                Move();
#endif

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
                Move(); 
#endif
        }

        private void Move()
        {
            if (rigidbody2D != null)
                rigidbody2D.velocity = Vector2.up * speed;
                jumpSFX.Play();
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe")) GameManager.Instance.GameOver();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("Pass") && GameManager.Instance.isGameOver == false) {
                GameManager.Instance.IncreaseScore(); scoreSFX.Play();
            } 
        }
    }
}