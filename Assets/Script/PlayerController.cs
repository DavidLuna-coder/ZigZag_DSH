using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6f;

    private Vector3 currentDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirecction();
        }
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * currentDirection;
    }
    void ChangeDirecction()
    {
        if (currentDirection == Vector3.forward)
        {
            currentDirection = Vector3.right;
        }
        else
        {
            currentDirection = Vector3.forward;
        }
    }
}
