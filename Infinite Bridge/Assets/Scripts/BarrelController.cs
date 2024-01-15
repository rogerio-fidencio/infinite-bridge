using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{

    private GameController _GameController;
    private Rigidbody2D barrelRb;

    private bool scored;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        barrelRb = GetComponent<Rigidbody2D>();
        barrelRb.velocity = new Vector2(-_GameController.barrelSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _GameController.destroyDistance)
        {
            Destroy(gameObject);
        }

        if (!scored && transform.position.x < _GameController.posXPlayer)
        {
            scored = true;
            _GameController.addScore(1);
        }
    }
}
