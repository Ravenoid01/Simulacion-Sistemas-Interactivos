using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] float time;
    private float currenttime; 
    [SerializeField, Range(0,1)]float parameter = 0;

    Vector3 initialPosition;
    Vector3 targetPosition;

    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private AnimationCurve curve;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        parameter = currenttime / time;
        transform.position = Vector3.LerpUnclamped(initialPosition, targetPosition, curve.Evaluate(parameter));
        spriteRenderer.color = Color.LerpUnclamped(initialColor, finalColor, curve.Evaluate(parameter));
        currenttime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }
    private void StartTween()
    {
        parameter = 0;
        currenttime = 0;
        initialPosition = transform.position;
        targetPosition = target.position;
    }

}
