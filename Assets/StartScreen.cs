using System.Collections;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Awake() => StartCoroutine(RemoveStartScreen());

    private IEnumerator RemoveStartScreen()
    {
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);
    }
}
