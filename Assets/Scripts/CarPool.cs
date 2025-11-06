using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class CarPool : MonoBehaviour
{
    public float qty = 3;
    public BoxCollider2D spawnBounds;
    private List<GameObject> pool;
    public GameObject carPrefab;
    
    private void Start()
    {
        pool = new List<GameObject>();
        // initialize pool
        for(int i = 0; i < qty; i++)
        {
            var tmp = Instantiate(carPrefab);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
        
        InvokeRepeating(nameof(SpawnCar),0, 2);
    }

    private void SpawnCar()
    {
        // Get Car
        var car = GetCar();
        if (car == null) return;

        var min = spawnBounds.bounds.min;
        var max = spawnBounds.bounds.max;

        var spawnPos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        car.transform.position = spawnPos;
        car.SetActive(true);
    }

    private GameObject GetCar()
    {
        foreach (var car in pool)
        {
            if (!car.activeInHierarchy)
            {
                // reset the car
                car.transform.rotation = Quaternion.identity;
                car.transform.position = spawnBounds.bounds.center;
                return car;
            }
        }
        return null;
    }
}
