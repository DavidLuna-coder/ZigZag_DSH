using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorStateManager : MonoBehaviour
{
    [SerializeField] GameObject floor;
    private float valX = 0f;
    private float valZ = 0f;
    private float valY = 0f;
    private float valueToIncrease;
    private const string FLOOR_TAG = "Floor";
    void Start()
    {
        valueToIncrease = floor.transform.localScale.z;
        valX = floor.transform.position.x;
        valZ = floor.transform.position.z;
        valY = floor.transform.position.y;
        CreateInitialFloor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateInitialFloor()
    {
        for (int i = 0; i < 3; i++)
        {
            valZ += valueToIncrease;
            Instantiate(floor, new Vector3(valX, 0, valZ), Quaternion.identity);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(FLOOR_TAG))
        {
            StartCoroutine(DeleteFloor(other.gameObject));
        }
    }

    private IEnumerator DeleteFloor(GameObject floorToDestroy)
    {
        float random = Random.Range(0.0f, 1.0f);

        if (random > 0.5)
            valX += valueToIncrease;
        else
            valZ += valueToIncrease;
        Instantiate(floorToDestroy, new Vector3(valX, 0, valZ), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        floorToDestroy.GetComponent<Rigidbody>().isKinematic = false;
        floorToDestroy.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(floorToDestroy);
    }
}
