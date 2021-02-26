using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{ 
    UP, RIGHT, DOWN, LEFT
}
public class PlayerController : MonoBehaviour
{

    public Vector2 objectivePosition;
    public Vector2 playerPosition;
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objectivePosition = new Vector2(transform.position.x, transform.position.y);
        speed = 3;
    }

    void Update()
    {
        playerPosition = new Vector2(transform.position.x, transform.position.y);  

        if (Input.GetKeyDown(KeyCode.UpArrow))
            MovePlayer(Direction.UP);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MovePlayer(Direction.RIGHT);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            MovePlayer(Direction.DOWN);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            MovePlayer(Direction.LEFT);

        if (objectivePosition != playerPosition)
        {
            transform.position = Vector3.MoveTowards(playerPosition, objectivePosition, speed * Time.deltaTime);
        }
    }

    public void MovePlayer(Direction dir)
    {
        float posX = transform.position.x;
        float posY = transform.position.y;

        switch (dir)
        {
            case Direction.UP:
                objectivePosition = new Vector2(posX, posY + 1);
                break;

            case Direction.RIGHT:
                objectivePosition = new Vector2(posX + 1, posY);
                break;

            case Direction.DOWN:
                objectivePosition = new Vector2(posX, posY - 1);
                break;

            case Direction.LEFT:
                objectivePosition = new Vector2(posX - 1, posY);
                break;
        }
    }
}
