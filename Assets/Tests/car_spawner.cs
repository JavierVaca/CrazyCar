using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class car_spawner
    {
        // A Test behaves as an ordinary method
        [Test]
        public void generate_correct_number_cars()
        {
            // Use the Assert class to test conditions
            GameObject[] gameObjects = new GameObject[8];
            CarSpawner carSpawner = new CarSpawner(gameObjects);

            float actualNumber = carSpawner.GetNumberCarsInactive();
            Assert.AreEqual(8, actualNumber);
        }

        [Test]
        public void set_car_active_moving()
        {
            GameObject[] gameObjects = new GameObject[8];
            CarSpawner carSpawner = new CarSpawner(gameObjects);
            
            carSpawner.SetActive(gameObjects[0], Vector3.zero);

            float actualNumberActive = carSpawner.GetNumberCarsActive();
            float actualNumberInactive = carSpawner.GetNumberCarsInactive();
            Assert.AreEqual(1, actualNumberActive);
            Assert.AreEqual(7, actualNumberInactive);
        }

        [Test]
        public void stop_all_cars()
        {
            GameObject[] gameObjects = new GameObject[8];
            CarSpawner carSpawner = new CarSpawner(gameObjects);

            carSpawner.SetAllInactive();

            float actualNumberInactive = carSpawner.GetNumberCarsInactive();
            Assert.AreEqual(8, actualNumberInactive);
        }

        [Test]
        public void set_car_inactive()
        {
            GameObject[] gameObjects = new GameObject[8];
            CarSpawner carSpawner = new CarSpawner(gameObjects);
            
            carSpawner.SetActive(gameObjects[0], Vector3.zero);
            carSpawner.SetActive(gameObjects[1], Vector3.zero);
            carSpawner.SetActive(gameObjects[2], Vector3.zero);
            carSpawner.SetInactive(gameObjects[0]);
            
            float actualNumberActive = carSpawner.GetNumberCarsActive();
            float actualNumberInactive = carSpawner.GetNumberCarsInactive();
            Assert.AreEqual(2, actualNumberActive);
            Assert.AreEqual(6, actualNumberInactive);
        }

        [Test]
        public void reuse_cars()
        {

        }

        [Test]
        public void go_through_all_cars_in_list()
        {
            GameObject[] gameObjects = new GameObject[8];
            CarSpawner carSpawner = new CarSpawner(gameObjects);
            
            var count = carSpawner.carsInactive.Count;
            for(int i = 0; i < count; i++)
            {
                carSpawner.SetActive(gameObjects[i], Vector3.zero);
            }
            
            float actualNumberActive = carSpawner.GetNumberCarsActive();
            float actualNumberInactive = carSpawner.GetNumberCarsInactive();
            Assert.AreEqual(8, actualNumberActive);
            //Assert.AreEqual(0, actualNumberInactive);
        }

        [Test]
        public void reset_all()
        {

        }
    }
}
