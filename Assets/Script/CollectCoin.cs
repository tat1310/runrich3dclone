using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public GameObject destroy;
    private void Update()
    {
        transform.Rotate(180 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMovement.sovang += 1;
            Destroy(gameObject);
            Debug.Log("Coin: " + PlayerMovement.sovang);
            if(destroy != null)
            {
                Instantiate(destroy, transform.position, Quaternion.identity);
            }
        }
        if (collision.tag == "bot")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
            return;
        }
    }
}
