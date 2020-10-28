using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject verticalLine, horizontalLine,travelPoint;
    private Vector3 _gridLines;
    [SerializeField] float verticalLines, horizontalLines;

    [HideInInspector]
    public List<Vector2> traversablePositions = new List<Vector2>();


    // Start is called before the first frame update
    void Awake()
    {
        _gridLines = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)); 
        verticalLines = (_gridLines.x * 2) - 1;
        horizontalLines = (_gridLines.y * 2) - 1;


        GenerateGrid(verticalLines, horizontalLines);
        GetTravelPoints();

    }

    private void GetTravelPoints()
    {
        for (int k = 0; k < verticalLines + 2; k++)
        {
            for (int l = 0; l < horizontalLines + 2; l++)
            {
                Vector2 tpPos = new Vector2(-_gridLines.x + k, -_gridLines.y + l);
                traversablePositions.Add(tpPos);

                //for visualizing traversable points
                var tPoint =Instantiate(travelPoint, tpPos, Quaternion.identity);
                //tPoint.name = traversiblePositions.Count.ToString();                
            }
        }
    }

    void GenerateGrid(float rows, float cols)
    {
        float _Xoffset = 1, _Yoffset = 1;

        for (int i = 0; i < rows; i++)
        {
            Vector3 nextPos = new Vector3(-_gridLines.x + _Xoffset, transform.position.y);
            _Xoffset += 1;
            GameObject vertLine = Instantiate(verticalLine, nextPos, Quaternion.identity);
            vertLine.transform.parent = transform;
        }
        for (int j = 0; j < cols; j++)
        {
            Vector3 nextPos = new Vector3(transform.position.x, -_gridLines.y + _Yoffset);
            _Yoffset += 1;
            GameObject hortLine = Instantiate(horizontalLine, nextPos, horizontalLine.transform.rotation);
            hortLine.transform.parent = transform;
        }
    }
}
