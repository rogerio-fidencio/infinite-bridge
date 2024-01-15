using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRB;

    public GameController _GameController;

    // Start is called before the first frame update
    void Start()
    {

        _GameController = FindAnyObjectByType(typeof(GameController)) as GameController;

        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float posY = transform.position.y;
        float posX = transform.position.x;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerRB.velocity = new Vector2(horizontal * _GameController.moveSpeed, vertical * _GameController.moveSpeed);
        
        if (transform.position.y > _GameController.limitMaxY)
        {
            posY = _GameController.limitMaxY;
        }
        else if (transform.position.y < _GameController.limitMinY)
        {
            posY = _GameController.limitMinY;
        }

        if (transform.position.x > _GameController.limitMaxX)
        {
            posX = _GameController.limitMaxX;
        }
        else if (transform.position.x < _GameController.limitMinX)
        {
            posX = _GameController.limitMinX;
        }

        transform.position = new Vector3(posX, posY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _GameController.changeScene("GameOver");
    }

}
