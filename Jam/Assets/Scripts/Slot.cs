using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Tile>().Colliding(gameObject);
    }

    public void KillMe()
    {
        Destroy(gameObject);
    }

    public void DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
