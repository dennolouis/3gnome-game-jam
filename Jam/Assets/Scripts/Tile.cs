using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    public GameObject slotNow;
    [SerializeField] GameObject slotPrefab;
    Color color;
    [SerializeField] GameObject gm;
    float maxDistance = 1;

    void Awake()
    {
        gm.GetComponent<GameManager>().activations += QuickActivation;

        int randNumber = UnityEngine.Random.Range(1, 4);

        if(randNumber == 1)
        {
            color = Color.red;
        }

        if (randNumber == 2)
        {
            color = Color.green;
        }

        if (randNumber == 3)
        {
            color = Color.blue;
        }

        if (randNumber == 4)
        {
            color = Color.yellow;
        }
    }

    IEnumerator FollowMouse()
    {
        while (true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 11f);

            yield return null;
        }
    }

    public void Colliding(GameObject slot)
    {
        slotNow = slot;
    }

    void OnMouseDown()
    {
        transform.Translate(Vector3.back * 0.1f);
        StartCoroutine("FollowMouse");
    }

    void OnMouseUp()
    {
        if (slotNow = null)
        {

        }
        transform.Translate(Vector3.forward * 0.1f);
        StopCoroutine("FollowMouse");

        transform.position = slotNow.transform.position;
    }

    public void SpawnSlots()
    {
        Ray lRay;
        Ray rRay;
        Ray uRay;
        Ray dRay;

        lRay = new Ray(transform.position, Vector3.left);
        rRay = new Ray(transform.position, Vector3.right);
        uRay = new Ray(transform.position, Vector3.up);
        dRay = new Ray(transform.position, Vector3.down);

        if(!Physics.Raycast(lRay, out RaycastHit hit1, maxDistance))
        {
            Instantiate(slotPrefab, new Vector3(transform.position.x -3, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (!Physics.Raycast(rRay, out RaycastHit hit2, maxDistance))
        {
            Instantiate(slotPrefab, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (!Physics.Raycast(uRay, out RaycastHit hit3, maxDistance))
        {
            Instantiate(slotPrefab, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        }

        if (!Physics.Raycast(dRay, out RaycastHit hit4, maxDistance))
        {
            Instantiate(slotPrefab, new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), Quaternion.identity);
        }
    }

    void QuickActivation(object sender, EventArgs e)
    {
        GetComponent<RuneBehaviour>().Activate();
    }

    public void FailedActivation()
    {
        Destroy(gameObject);
    }

    public Color CheckAdjacentTiles(Vector3 dir)
    {
        Color col = Color.gray;

        return col;
    }
}