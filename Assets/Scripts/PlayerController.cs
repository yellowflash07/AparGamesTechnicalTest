using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _direction, _screenSize;
    public float speed;

    public SwipeDetect swipeDetect;
    public Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = grid.traversablePositions[39];

        _screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
        CheckForTraversablePoints();
        CheckExit();
    }

    private void CheckExit()
    {
        if (transform.position.x > _screenSize.x || transform.position.y > _screenSize.y ||
            transform.position.x < -_screenSize.x || transform.position.y < -_screenSize.y)
        {
            if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Down || swipeDetect.detectedSwipe == SwipeDetect.Swipe.Up)
                transform.position = new Vector3(transform.position.x, -transform.position.y);
                
                

            if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Left || swipeDetect.detectedSwipe == SwipeDetect.Swipe.Right)
                transform.position = new Vector3(-transform.position.x, transform.position.y);
        }
    }

    private void CheckForTraversablePoints()
    {
        foreach (var tp in grid.traversablePositions)
        {
            if (System.Math.Round(transform.position.y, 1) == System.Math.Round(tp.y, 1))
            {
                if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Right)
                {
                    _direction = Vector3.right;
                }
                else if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Left)
                {
                    _direction = Vector3.left;
                }
            }

            else if (System.Math.Round(transform.position.x, 1) == System.Math.Round(tp.x, 1))
            {
                if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Up)
                {
                    _direction = Vector3.up;
                }
                else if (swipeDetect.detectedSwipe == SwipeDetect.Swipe.Down)
                {
                    _direction = Vector3.down;
                }
            }
        }
    }

}
