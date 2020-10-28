using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetect : MonoBehaviour
{
    private Vector3 _firstTouch, _lastTouch, _swipeDirection;
    public Text  _swipeDirectionText;

    public enum Swipe
    {
        Up,
        Down,
        Left,
        Right
    }

    public Swipe detectedSwipe;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _firstTouch = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                _lastTouch = touch.position;
            }

            _swipeDirection = (_firstTouch - _lastTouch).normalized;

            if ( _swipeDirection.y < -0.9)
            {
                detectedSwipe = Swipe.Up;
                 _swipeDirectionText.text = "Swiped Up";
            }
            else if ( _swipeDirection.y > 0.9)
            {
                detectedSwipe = Swipe.Down;
                 _swipeDirectionText.text = "Swiped Down";
            }
            else if ( _swipeDirection.x < -0.9)
            {
                detectedSwipe = Swipe.Right;
                 _swipeDirectionText.text = "Swiped Right";
            }
            else if( _swipeDirection.x > 0.9)
            {
                detectedSwipe = Swipe.Left;
                 _swipeDirectionText.text = "Swiped Left";
            }
        }
    }
}
