using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;

    public AudioSource changeEffect;
    public GameObject bananaeffect;
    public GameObject watermeloneffect;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "skinbanana")
        {
            rend.sharedMaterial = materials[0];
            //Debug.Log("Doi skin");
            Destroy(other.gameObject);
            changeEffect.Play();
            Instantiate(bananaeffect, transform.position, Quaternion.identity);
        }
        if (other.tag == "skinwatermelon")
        {
            rend.sharedMaterial = materials[1];
            //Debug.Log("Doi skin");
            Destroy(other.gameObject);
            changeEffect.Play();
            Instantiate(watermeloneffect, transform.position, Quaternion.identity);
        }
    }
}
