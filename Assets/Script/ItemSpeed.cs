using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : MonoBehaviour
{
    public float tocdoitem = 5;
    private void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        BotMovement bot = other.GetComponent<BotMovement>();
        if(other.tag == "Player")
        {
            player.itemspeed(player.speedMove + tocdoitem);
            //Debug.Log("Tang toc do thanh" + (player.speedMove + tocdoitem));
            Destroy(gameObject);
        }
        if (other.tag == "bot")
        {
            bot.itemspeed(bot.speedMove + tocdoitem);
            Destroy(gameObject);
        }
    }
}
