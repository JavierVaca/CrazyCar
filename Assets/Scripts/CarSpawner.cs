using System;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner {

    public List<GameObject> carsInactive;
    public List<GameObject> carsActive;
    public float speed;
    private float objectSeparation;
    private Vector3 initialPosition;
    public Vector3 left;
    public Vector3 center;
    public Vector3 right;


    public CarSpawner(GameObject[] objects)
    {
        PopulateLists(objects);
    }

    public CarSpawner(GameObject[] objects, Vector3 position, float speed, float objectSeparation)
    {
        initialPosition = position;
        this.speed = speed;
        this.objectSeparation = objectSeparation;
        center = position;
        left = new Vector3(position.x - objectSeparation, position.y, position.z);
        right = new Vector3(position.x + objectSeparation, position.y, position.z);
        PopulateLists(objects);
    }

    public void SetActive(GameObject gameObject, Vector3 position)
    { 
        var rbd = gameObject?.GetComponent<Rigidbody>();
        if(rbd != null)
        {
            var direction = new Vector3(0,0,-1);
            rbd.velocity = direction * speed;
            gameObject.transform.position = position;
        }
        carsInactive.Remove(gameObject);
        carsActive.Add(gameObject);
        gameObject?.SetActive(true);
    }

    public void SetAllInactive()
    {
        var allActive = carsActive.Count;
        for(int i=0; i<allActive; i++)
        {
            SetInactive(carsActive[carsActive.Count-1]);
        }
    }

    internal void KeepSpeedAndDispose()
    {
        if(carsActive != null || carsActive.Count <= 0)
        {
            for(int i = 0; i < carsActive.Count; i++)
            {
                var rbd = carsActive[i]?.GetComponent<Rigidbody>();
                rbd.velocity = (Vector3.Normalize(rbd.velocity) * speed);
                if(carsActive[i].transform.position.y < 0)
                {
                    SetInactive(carsActive[i]);
                }
            }
        }
    }

    public void SetActive(Vector3 position)
    {
        if(carsInactive.Count > 0)
        {
            var random = UnityEngine.Random.Range(0, carsInactive.Count);
            SetActive(carsInactive[random], position);
        }
    }

    public void SetInactive(GameObject gameObject)
    {
        gameObject?.SetActive(false);
        var rbd = gameObject?.GetComponent<Rigidbody>();
        if(rbd!=null)
        {
            rbd.AddForce(Vector3.zero);
        }
        carsInactive.Add(gameObject);
        carsActive.Remove(gameObject);
    }

    public float GetNumberCarsInactive()
    {
        return carsInactive.Count;
    }
    public float GetNumberCarsActive()
    {
        return carsActive.Count;
    }

    void PopulateLists(GameObject[] objects)
    {
        carsInactive = new List<GameObject>();
        carsActive = new List<GameObject>();
        for(int i = 0; i < objects.Length; i++)
        {
            carsInactive.Add(objects[i]);
        }
    }

    public void GenerateRow()
    {
        var position = GenerateRowPositions();
        for(int i = 0; i < position.Length; i++)
        {
            SetActive(position[i]);
        }
        if(position.Length >= 3)
        {

        }
    }

    public Vector3[] GenerateRowPositions()
    {
        Vector3[] v;
        //Max posibilities are 6 (3 cars 3 positions)
        var combination = UnityEngine.Random.Range(0, 5);
        if(combination == 0)
        {
            v = new Vector3[1]
            {
                left
            };
        }
        else if(combination == 1)
        {
            v = new Vector3[2]
            {
                left,
                center
            };
        }
        else if(combination == 2)
        {
            v = new Vector3[3]
            {
                left,
                center,
                right
            };
        }
        else if(combination == 3)
        {
            v = new Vector3[1]
            {
                center
            };
        }
        else if(combination == 4)
        {
            v = new Vector3[2]
            {
                center,
                right
            };
        }
        else 
        {
            v = new Vector3[1]
            {
                right
            };
        }
        return v;
    }
}