using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public void ShakeItUp()
    {
        StartCoroutine(Shake(.7f, .2f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            //float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }


}