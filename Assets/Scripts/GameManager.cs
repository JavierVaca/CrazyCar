using UnityEngine;
using TMPro;

namespace CrazyCar
{
    public class GameManager : MonoBehaviour {
        public StreetMover streetMover;
        public CarManager carManager;
        public PlayerController player;
        public TextMeshProUGUI text;
        public float maxSpeed;
        private int score;

        void Start()
        {
            InvokeRepeating("IncreaseLevel", 4.0f, 4.0f);
            text.text = "Score: " + score;
            maxSpeed = carManager.carSpeed * 2;
        }

        void Update()
        {
            
        }

        void IncreaseLevel()
        {
            if(carManager.carSpeed >= maxSpeed)
            {
                streetMover.speed += streetMover.speed * 0.10f;
                carManager.SetCarSpeed(carManager.carSpeed + carManager.carSpeed * 0.10f);
            }
            score += 10;
            text.SetText( "Score: " + score);
        }

        public void StopGame()
        {
            carManager.SetCarSpeed(0);
            streetMover.speed = 0;
            carManager.CancelInvoke();
            streetMover.CancelInvoke();
            CancelInvoke();
        }

        public void RestartGame()
        {
            carManager.ResetAll();
            streetMover.Reset();
            player.ResetPosition();
            score = 0;
            text.SetText( "Score: " + score);
            InvokeRepeating("IncreaseLevel", 4.0f, 4.0f);
        }
    }
}
