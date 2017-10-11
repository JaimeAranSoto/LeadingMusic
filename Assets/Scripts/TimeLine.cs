using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour
{
    public string identifier;
    public GameObject beat;
    public GameObject limit;
    private Vector2 scale;
    // Use this for initialization
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(scale.x, scale.y), 4 * Time.deltaTime);
    }
    public void Beat(double sampleTime)
    {
        transform.localScale = new Vector2(scale.x * 1.15f, scale.y * 1.15f);
        GameObject newBeat = Instantiate(beat,transform.parent);
        newBeat.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        newBeat.GetComponent<Beat>().speed = (float)((newBeat.transform.position.y - limit.transform.position.y) * 44100 / sampleTime)/2;
    }
}
