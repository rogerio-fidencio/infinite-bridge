using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    private GameController _GameController;
    private Rigidbody2D bridgeRb;

    private bool instantiated;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;

        bridgeRb = GetComponent<Rigidbody2D>();

        bridgeRb.velocity = new Vector2(_GameController.bridgeSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (instantiated == false)
        {
            if (transform.position.x <= 0)
            {
                instantiated = true;
                GameObject tempBridge = Instantiate(_GameController.bridgePrefab);
                float posX = transform.position.x + _GameController.bridgeSize;
                float posY = transform.position.y;
                tempBridge.transform.position = new Vector3(posX, posY, 0);
            }
        }

        if (transform.position.x <= _GameController.destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
