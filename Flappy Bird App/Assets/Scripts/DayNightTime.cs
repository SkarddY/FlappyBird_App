using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace FlappyBird {

    public class DayNightTime : MonoBehaviour
    {
        [SerializeField] UnityEvent onDay, onNight;
        [SerializeField] public bool isDay, isNight;

        public void Awake() {
            float randNumber = Random.Range(0f, 1f);

            if (randNumber > 0.5f) {
                isDay = true; onDay.Invoke(); isNight = false;
            }
            else if (randNumber < 0.5f) {
                isNight = true; onNight.Invoke(); isDay = false;
            } 

        }

    }

}
