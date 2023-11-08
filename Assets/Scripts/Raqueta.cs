using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    [SerializeField] private float velocidad = 10.0f;
    [SerializeField] private string eje;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(eje);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
