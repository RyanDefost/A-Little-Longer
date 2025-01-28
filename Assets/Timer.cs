using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _elapsedSeconds;

    private void Awake() => StartCoroutine(GameTime());

    private IEnumerator GameTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _elapsedSeconds++;
        }
    }

    public float GetElapsedTime() => _elapsedSeconds;
}
