using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject slottedTile;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Tile>().Colliding(gameObject);
    }

    void KillMe()
    {
        Destroy(gameObject);
    }

    public void slotTile(GameObject tile, GameObject slotToSwapTo)
    {
        if(slottedTile != null)
        {
            slottedTile.transform.position = slotToSwapTo.transform.position;
            slotToSwapTo.GetComponent<Slot>().slottedTile = slottedTile;

            tile.transform.position = gameObject.transform.position;
            slottedTile = tile;
        }

        else
        {
            tile.transform.position = gameObject.transform.position;
            slottedTile = tile;
        }
    }
}
