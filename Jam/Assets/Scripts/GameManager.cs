using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> runeQueu1 = new List<GameObject>();
    List<GameObject> runeQueu2 = new List<GameObject>();

    void ActivateRunes()
    {

    }
}

public interface RuneBehaviour
{
    public void Condition()
    {

    }

    public void Effect()
    {

    }
}