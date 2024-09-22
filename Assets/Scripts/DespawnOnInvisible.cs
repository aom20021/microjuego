using UnityEngine;

public class DespawnOnInvisible : MonoBehaviour
{
    bool isInvisible = false;

    private void OnBecameVisible()
    {
        isInvisible = false;
    }

    private void Update()
    {
        if (isInvisible)
            gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        isInvisible = true;
    }
}
