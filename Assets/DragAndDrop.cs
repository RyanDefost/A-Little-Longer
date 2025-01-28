using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private GameObject _currentObject = null;

    // Start is called before the first frame update
    void Start()
    {

    }

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
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _currentObject = null;
        }

        if (_currentObject != null)
            _currentObject.transform.position = rayOrigin;
    }
}
