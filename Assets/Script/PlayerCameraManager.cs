using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = playerCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerCamera.transform.position = transform.position + offset;
    }
}
