using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject _currentObject = null;
    private Collider2D _currentCollider = null;
    private PuzzleSpawner _spawner;

    public float gridSize = 1f;

    private float snapDistance = 0.5f;

    void Start() => _spawner = FindAnyObjectByType<PuzzleSpawner>();

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos;
        Vector2 rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition).origin;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(rayOrigin, Vector3.forward))
            {
                if (hit.transform.gameObject.layer != 6)
                    return;

                _currentObject = hit.transform.gameObject;
                _currentCollider = hit.collider;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _currentObject = null;
        }

        if (_currentObject != null)
        {
            //var posX = RoundToNearestGrid(rayOrigin.x);
            //var posY = RoundToNearestGrid(rayOrigin.y);

            var posX = MathF.Round(rayOrigin.x);
            var posY = MathF.Round(rayOrigin.y);

            posX = SnapPos(posX, rayOrigin.x);
            posY = SnapPos(posY, rayOrigin.y);

            _currentObject.transform.position = new Vector2(posX, posY);
        }
        ///
        //offset = Vector3.zero;
        //_currentObject.transform.position = rayOrigin;
    }

    private float SnapPos(float pos, float originalPos)
    {
        if (originalPos - pos < 0.25)
        {
            pos = Mathf.Ceil(pos);
        }
        else if (originalPos - pos > 0.75)
        {
            pos = Mathf.Floor(pos);
        }
        else
        {
            pos += 0.5f;
        }

        return pos;
    }

    //Code: https://gamedevbeginner.com/how-to-snap-objects-in-game-in-unity/
    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        bool isPositive = pos > 0 ? true : false;
        pos -= xDiff;
        if (Mathf.Abs(xDiff) > (gridSize / 2))
        {
            if (isPositive)
            {
                pos += gridSize;
            }
            else
            {
                pos -= gridSize;
            }
        }
        return pos;
    }
}
