using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FloorStateManager : MonoBehaviour
{
    [SerializeField] GameObject floor;
    [SerializeField] GameObject price;
    [SerializeField] GameObject gem;
    [SerializeField] PlayerController player;
    [SerializeField] TextMeshProUGUI scoreText;
    private float valX = 0f;
    private float valZ = 0f;
    private float valY = 0f;
    private int phase = 0;
    private float starY= 0f;
  
    private float valueToIncrease;
    private int totalpoints=0;
    private float baseSpeed = 0;
    private const string FLOOR_TAG = "Floor";
    private const string PRICE_TAG = "price";
    private const string GEM_TAG = "Gem";
    private float speedMultiplier = 1;
    void Start()
    {
        valueToIncrease = floor.transform.localScale.z;
        valX = floor.transform.position.x;
        valZ = floor.transform.position.z;
        valY = floor.transform.position.y;
        starY = 0.5f;
        baseSpeed = player.speed;
        CreateInitialFloor();
    }

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = "Score: " + totalpoints;
        player.speed = baseSpeed * speedMultiplier;

        if (totalpoints > 140 && phase == 3){
            speedMultiplier = 1.8f;
            phase++;
            return;
        }
        if (totalpoints > 70 && phase == 2){
            speedMultiplier = 1.5f;
            phase++;
            return;
        }
        if (totalpoints > 50 && phase == 1){
            speedMultiplier = 1.25f;
            phase++;
            return;
        }
        if (totalpoints > 20 && phase == 0){
            speedMultiplier = 1.1f;
            phase++;
            return;
        }
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
            totalpoints++;
            StartCoroutine(DeleteFloor(other.gameObject));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PRICE_TAG))
        {
            
            totalpoints+=3;
            Destroy(other.gameObject);
        }
        else
        {
            if (other.gameObject.CompareTag(GEM_TAG))
            {
                totalpoints++;
                Debug.Log(totalpoints);
                Destroy(other.gameObject);
            }
        }
    }

    private IEnumerator DeleteFloor(GameObject floorToDestroy)
    {
        float random = Random.Range(0.0f, 1.0f);
        float randomStar = Random.Range(0.0f, 1.0f);

        if (random > 0.5)
            valX += valueToIncrease;
        else
            valZ += valueToIncrease;

        if (randomStar > 0.5)
            if(randomStar>0.75)
                Instantiate(price, new Vector3(valX, starY, valZ), transform.rotation * Quaternion.Euler (-90.0f, 0, 0));
            else
                Instantiate(gem, new Vector3(valX, starY, valZ), transform.rotation * Quaternion.Euler (-90.0f, 0, 0));
        
        
        Instantiate(floorToDestroy, new Vector3(valX, 0, valZ), Quaternion.identity);
        
        yield return new WaitForSeconds(0.5f);
        floorToDestroy.GetComponent<Rigidbody>().isKinematic = false;
        floorToDestroy.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        Destroy(floorToDestroy);
    }

 
}
