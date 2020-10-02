using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    CarSpawner CarSpawner;
    public float carSpeed;
    private float startSpeed;
    [SerializeField]
    public GameObject[] carPrefabs;
    public float objectSeparation;
    // Start is called before the first frame update
    void Start()
    {
        CarSpawner = new CarSpawner(InstantiateAllCars(), gameObject.transform.position, carSpeed, objectSeparation);
        InvokeRepeating("SetCars", 2f, 1f);
        startSpeed = carSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CarSpawner.KeepSpeedAndDispose();
    }

    private GameObject[] InstantiateAllCars()
    {
        int carsLength = carPrefabs.Length;
        var result = new GameObject[carsLength * 2];
        for(int i = 0; i < carPrefabs.Length; i++)
        {
            //Account for object duplication
            var resultIndex = i*2;
            var g = Instantiate(carPrefabs[i]);
            var g1 = Instantiate(carPrefabs[i]);
            g.SetActive(false);
            g1.SetActive(false);
            result.SetValue(g, resultIndex);
            result.SetValue(g1, resultIndex + 1);
        }
        return result;
    }

    internal void ResetAll()
    {
        CarSpawner.SetAllInactive();
        InvokeRepeating("SetCars", 2f, 1f);
        SetCarSpeed(startSpeed);
    }

    private void SetCars()
    {
        CarSpawner.GenerateRow();
    }

    public void SetCarSpeed(float speed)
    {
        this.carSpeed = speed;
        CarSpawner.speed = speed;
    }
}
