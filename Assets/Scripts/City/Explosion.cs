using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 explosionPos = transform.position;
            Instantiate(explosionEffect, explosionPos, Quaternion.identity);
            EventManager.TriggerExplosion(explosionPos);
        }
    }
}
