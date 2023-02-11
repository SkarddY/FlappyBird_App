using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [Space, SerializeField, Range(-1, 1)] private float minHeight, maxHeight;
        [SerializeField] private float timeToSpawnPipe;

        //Change Pipe color
        [SerializeField] GameObject timeChangeObj;
        private DayNightTime timeChange;

        private void Awake() {
            if (timeChangeObj != null) {
                this.timeChange = timeChangeObj.GetComponent<DayNightTime>();
            }
        }

        private void Start()
        {
            if (timeChange.isDay == true) {
                StartCoroutine(SpawnPipesDay());
            }
            else if (timeChange.isNight == true) {
                StartCoroutine(SpawnPipesNight());
            }

        }

        private Vector3 GetSpawnPos() {
            return new Vector3(spawnPoint.position.x, Random.Range(minHeight, maxHeight), spawnPoint.position.z);
        }

        private IEnumerator SpawnPipesDay()
        {
            do
            {
                yield return new WaitForSeconds(timeToSpawnPipe);

                //Pipe pooling day

                GameObject pipe = PipePooling.SharedInstance.GetPooledPipes();
                if (pipe != null) {
                    pipe.transform.position = GetSpawnPos();
                    pipe.SetActive(true);
                }

            } while (true);
        }

        private IEnumerator SpawnPipesNight()
        {
            do
            {
                yield return new WaitForSeconds(timeToSpawnPipe);

                //Pipe pooling night

                GameObject pipe = NightPooling.SharedInstance.GetPooledPipes();
                if (pipe != null) {
                    pipe.transform.position = GetSpawnPos();
                    pipe.SetActive(true);
                }

            } while (true);
        }

        public void Stop() {
            StopAllCoroutines();
        }
    }
}