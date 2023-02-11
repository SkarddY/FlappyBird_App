using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{

    public class NightPooling : MonoBehaviour
    {
        public static NightPooling SharedInstance;
        public List<GameObject> pooledPipes;
        public GameObject pipeToPool;
        public int amountToPool;

        private void Awake() {
            SharedInstance = this;
        }
        private void Start() {
            pooledPipes = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++) {
                tmp = Instantiate(pipeToPool);
                tmp.SetActive(false);
                pooledPipes.Add(tmp);
            }
        }

        public GameObject GetPooledPipes()
        {
            for (int i = 0; i < amountToPool; i++) {
                if (!pooledPipes[i].activeInHierarchy) {
                    return pooledPipes[i];
                }
            }
            return null;
        }
    }
}
