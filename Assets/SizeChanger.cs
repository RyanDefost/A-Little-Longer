using System.Collections;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] private float _SecondsWaiting = 10;
    [SerializeField] private float _desiredScale = 0.5f;

    private void Start() => StartCoroutine(DecreaseSize());

    private IEnumerator DecreaseSize()
    {
        var currentScale = gameObject.transform.localScale;

        for (float i = 0; i < 1; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f * _SecondsWaiting);

            float scaling = Mathf.Lerp(currentScale.x, _desiredScale, i);
            gameObject.transform.localScale = new Vector3(scaling, scaling, 0);
        }
    }
}
