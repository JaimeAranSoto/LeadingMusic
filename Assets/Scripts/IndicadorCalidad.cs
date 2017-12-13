using UnityEngine;
using System.Collections;

public class IndicadorCalidad : MonoBehaviour
{
    private float total;
    float ancho;
    void Start()
    {
        ancho = transform.parent.GetComponent<RectTransform>().sizeDelta.x;


    }

    void Update()
    {
        RectTransform rect = GetComponent<RectTransform>();
        total = RythmManager.Instance.currentQuality / RythmManager.Instance.maxQuality;

        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, new Vector2(total * ancho, rect.anchoredPosition.y), 4 * Time.deltaTime);
        
    }
}