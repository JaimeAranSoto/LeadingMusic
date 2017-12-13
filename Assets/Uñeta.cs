using UnityEngine;
using System.Collections;

public class Uñeta : Singleton<Uñeta>
{

    void Start()
    {

    }

    void Update()
    {

    }
    IEnumerator goToPosition(Transform newPosition)
    {
        RectTransform rect = GetComponent<RectTransform>();
        while (!rect.localPosition.Equals(Vector3.zero))
        {
            rect.localPosition = Vector3.Lerp(rect.localPosition, Vector3.zero, 1.3f * Time.deltaTime);
            yield return null;
        }
        
    }
    public void SetPosition(Transform newPosition)
    {
        StopAllCoroutines();
        transform.parent = newPosition;
        StartCoroutine(goToPosition(newPosition));

        // GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}