using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphFunction : MonoBehaviour
{
    [SerializeField] private GameObject point_Prefab;
    [SerializeField] private int totalSamples = 10;
    [SerializeField] private float separation = 1f;
    GameObject[] m_points;

    void Start()
    {
        m_points = new GameObject[totalSamples];
        for(int i = 0 ;i < totalSamples; i++)
        {
            m_points[i] = Instantiate(point_Prefab, transform);

        }
        
    }
    private void UpdatePoints()
    {
        for (int i = 0; i < totalSamples; i++)
        {
            var newPoint = m_points[i];
            Vector3 currPosition = newPoint.transform.position;

            currPosition.x = i * separation;
            currPosition.y = Mathf.Sin(currPosition.x + Time.time);

            newPoint.transform.localPosition = currPosition;

        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePoints();
    }
}
