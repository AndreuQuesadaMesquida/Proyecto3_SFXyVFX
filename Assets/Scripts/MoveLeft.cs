using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const string OBSTACLE_TAG = "Obstacle";

    [SerializeField] private float speed = 10f;

    private PlayerController playerControllerScript; // = null
    public float leftBound = -6f;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime,
                Space.World);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag(OBSTACLE_TAG))
        {
            Destroy(gameObject);
        }
    }
}
