using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject slotNow;
    GameObject slotPrevious;
    [SerializeField] GameObject slotPrefab;

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
        slotNow.GetComponent<Slot>().EnableCollider();
        slotPrevious = slotNow;
        slotNow = slot;
        slotNow.GetComponent<Slot>().DisableCollider();
    }

    void OnMouseDown()
    {
        transform.Translate(Vector3.back * 0.1f);
        StartCoroutine("FollowMouse");
    }

    void OnMouseUp()
    {
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
        float maxDistance = 1;

        lRay = new Ray(transform.position, Vector3.left);
        rRay = new Ray(transform.position, Vector3.right);
        uRay = new Ray(transform.position, Vector3.up);
        dRay = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(lRay, out RaycastHit hit1, maxDistance))
        {
            Instantiate(slotNow, new Vector3(transform.position.x -3, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (Physics.Raycast(rRay, out RaycastHit hit2, maxDistance))
        {
            Instantiate(slotNow, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), Quaternion.identity);
        }

        if (Physics.Raycast(uRay, out RaycastHit hit3, maxDistance))
        {
            Instantiate(slotNow, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        }

        if (Physics.Raycast(dRay, out RaycastHit hit4, maxDistance))
        {
            Instantiate(slotNow, new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), Quaternion.identity);
        }
    }

    public void FetchInfo()
    {

    }
}