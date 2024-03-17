using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    List<GameObject> runeQueu1 = new List<GameObject>();
    List<GameObject> runeQueu2 = new List<GameObject>();
    List<GameObject> runeQueu3 = new List<GameObject>();

    List<GameObject> chosenRunes = new List<GameObject>();

    public event EventHandler activations;

    public void EndTurn()
    {
        activations?.Invoke(this, EventArgs.Empty);

        foreach (GameObject rune in runeQueu1)
        {
            rune.GetComponent<RuneBehaviour>().Activate();
        }

        foreach (GameObject rune in runeQueu2)
        {
            rune.GetComponent<RuneBehaviour>().Activate();
        }

        foreach (GameObject rune in runeQueu3)
        {
            rune.GetComponent<RuneBehaviour>().Activate();
        }
    }

    IEnumerator StartPlacing()
    {
        chosenRunes[0] = Instantiate(chosenRunes[0]);
        while(chosenRunes[0].GetComponent<Tile>().slotNow = null)
        {
            yield return null;
        }

        chosenRunes[1] = Instantiate(chosenRunes[0]);
        while (chosenRunes[1].GetComponent<Tile>().slotNow = null)
        {
            yield return null;
        }

        chosenRunes[2] = Instantiate(chosenRunes[0]);
        while (chosenRunes[2].GetComponent<Tile>().slotNow = null)
        {
            yield return null;
        }
    }
}

public interface RuneBehaviour  
{
    public void Activate()
    {

    }

    public void Effect()
    {

    }
}