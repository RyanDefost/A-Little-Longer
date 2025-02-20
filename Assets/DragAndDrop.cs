using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float minSnapDistance = 0.25f;
    [SerializeField, Range(0, 1)] private float maxSnapDistance = 0.75f;
    private Vector2 minMaxSnapDistance;

    private GameObject currentObject = null;

    private void Start() => minMaxSnapDistance = new Vector2(minSnapDistance, maxSnapDistance);

    void Update()
    {
        Vector2 rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        SetRaycast(rayOrigin);

        UpdatePosition(this.currentObject, rayOrigin);
    }

    /// <summary>
    /// Casts a Ray based on if the correct input is given and sets the currentObject
    /// </summary>
    /// <param name="rayOrigin"></param>
    private void SetRaycast(Vector2 rayOrigin)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(rayOrigin, Vector3.forward))
            {
                puzzlePiece piece;
                hit.transform.gameObject.TryGetComponent(out piece);

                if (piece == null)
                    return;

                this.currentObject = hit.transform.gameObject;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            this.currentObject = null;
    }

    /// <summary>
    /// Sets the position of the currentObject to snap to a grid.
    /// </summary>
    /// <param name="currentObject">The current object the player is holding.</param>
    /// <param name="movePosition">The position the object has at the moment.</param>
    private void UpdatePosition(GameObject currentObject, Vector2 movePosition)
    {
        if (currentObject == null)
            return;

        float positionX = MathF.Round(movePosition.x);
        float positionY = MathF.Round(movePosition.y);

        positionX = SnapPos(positionX, movePosition.x, minMaxSnapDistance);
        positionY = SnapPos(positionY, movePosition.y, minMaxSnapDistance);

        this.currentObject.transform.position = new Vector2(positionX, positionY);
    }

    /// <summary>
    /// Tries to snap to a grid, based on the given parameters.
    /// </summary>
    /// <returns>returns the position snapped on a grid.</returns>
    private float SnapPos(float position, float originalPos, Vector2 minMaxDistance)
    {
        if (originalPos - position < minMaxDistance.x)
            return Mathf.Ceil(position);

        if (originalPos - position > minMaxDistance.y)
            return Mathf.Floor(position);

        return position += 0.5f;
    }
}
