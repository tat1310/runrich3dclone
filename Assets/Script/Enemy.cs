using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        BotMovement bot = other.GetComponent<BotMovement>();
        if (other.tag == "Player")
        {
            player.chamchuongngaivat(0);
            //Debug.Log("Giam toc ve 0");
        }
        if (other.tag == "bot")
        {
            bot.chamchuongngaivat(0);
        }
    }
}
