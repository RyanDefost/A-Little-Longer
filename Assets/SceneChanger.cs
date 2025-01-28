using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(float CameraOffset)
    {
        Camera.main.gameObject.transform.position += new Vector3(CameraOffset, 0, 0);
    }
}
