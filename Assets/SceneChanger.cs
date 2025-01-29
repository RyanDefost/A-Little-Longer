using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float _emitterChange;
    private FMODUnity.StudioEventEmitter emitter;
    private void Start()
    {
        emitter = FindAnyObjectByType<FMODUnity.StudioEventEmitter>();
    }

    public void ChangeScene(float CameraOffset)
    {
        emitter.SetParameter("puzzel", _emitterChange);
        Camera.main.gameObject.transform.position += new Vector3(CameraOffset, 0, 0);
    }
}
