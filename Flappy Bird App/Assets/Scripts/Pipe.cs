using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update() {
            if (GameManager.Instance.isGameOver) return;
            transform.position += (Vector3.left * Time.deltaTime * speed);

            //This is better in Update for Pooling
            StartCoroutine(DestroyPipe());
        }

        private IEnumerator DestroyPipe() {
            yield return new WaitForSeconds(2.5f);
            gameObject.SetActive(false);
        }
    }
}