using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject coin;
    public GameObject obstacle;
    public GameObject itemspeed;
    void Start()
    {
        SpawnCoin();
        SpawnObStacle();
        SpawnItem();
    }
    void SpawnCoin()
    {
        int coinsSpawn = Random.Range(5, 10);
        for(int i = 0; i < coinsSpawn; i++)
        {
            GameObject temp = Instantiate(coin);
            temp.transform.position = RandomPointCoin(GetComponent<Collider>());
        }
    }
    void SpawnObStacle()
    {
        int obstacleSpawn = Random.Range(1,3);
        for (int i = 0; i < obstacleSpawn; i++)
        {
            GameObject temp = Instantiate(obstacle);
            temp.transform.position = RandomPointObstacle(GetComponent<Collider>());
        }
    }
    void SpawnItem()
    {
        int itemSpawn = Random.Range(0, 2);
        for (int i = 0; i < itemSpawn; i++)
        {
            GameObject temp = Instantiate(itemspeed);
            temp.transform.position = RandomPointItem(GetComponent<Collider>());
        }
    }
    Vector3 RandomPointCoin(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = RandomPointCoin(collider);
        }
        point.y = 1;
        return point;
    }
    Vector3 RandomPointObstacle(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = RandomPointObstacle(collider);
        }
        point.y = 0.5f;
        return point;
    }
    Vector3 RandomPointItem(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = RandomPointItem(collider);
        }
        point.y = 1f;
        return point;
    }
}
