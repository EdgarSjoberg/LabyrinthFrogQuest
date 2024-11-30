using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterPusher : MonoBehaviour
{
    [SerializeField] MapScript mapScript;
    int mapDepth;
    int mapWidth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckMoveInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetPushDirection();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CanMove(MoveDirection.Up))
            {
                //moveTurn = false;
                transform.position += new Vector3(0, 1, 0);
            }

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CanMove(MoveDirection.Down))
            {
                //moveTurn = false;
                transform.position += new Vector3(0, -1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CanMove(MoveDirection.Right))
            {
                //moveTurn = false;
                transform.position += new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CanMove(MoveDirection.Left))
            {
                //moveTurn = false;
                transform.position += new Vector3(-1, 0, 0);
            }
        }
    }
    bool CanMove(MoveDirection moveDirection)
    {

        switch (moveDirection)
        {
            case MoveDirection.Up:
                if (transform.position.y <= mapScript.MapDepth - 1)
                {
                    if (transform.position.x < 0 || transform.position.x > mapScript.MapWidth - 1)
                    {
                        return true;
                    }
                }
                break;
            case MoveDirection.Down:
                if (transform.position.y > -1)
                {
                    if (transform.position.x < 0 || transform.position.x > mapScript.MapWidth - 1)
                    {
                        return true;
                    }
                }
                break;
            case MoveDirection.Right:
                if (transform.position.x <= mapScript.MapWidth - 1)
                {
                    if (transform.position.y < 0 || transform.position.y > mapScript.MapDepth - 1)
                    {
                        return true;
                    }
                }
                break;
            case MoveDirection.Left:
                if (transform.position.x > -1)
                {
                    if (transform.position.y < 0 || transform.position.y > mapScript.MapDepth - 1)
                    {
                        return true;
                    }
                }
                break;
        }

        return false;
    }

    public void GetPushDirection()
    {
   
        if (transform.position.x > -1 || transform.position.x < mapScript.MapWidth + 1)
        {
            if (transform.position.y == -1)
                Debug.Log("Pusher Push Up");

            else if(transform.position.y == mapDepth)
                Debug.Log("Pusher Push Down");
        }

        else if (transform.position.y < -1 || transform.position.y > mapScript.MapDepth + 1)
        {
             if (transform.position.x == -1)
                Debug.Log("Pusher Push Right");

            else if(transform.position.x == mapWidth + 1)
                Debug.Log("Pusher Push Left");
        }
    }
}
    

