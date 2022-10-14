using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{

    public Vector2 velocidadMov;

    public Vector2 offset;

    private Material material;

    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocidadMov * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
