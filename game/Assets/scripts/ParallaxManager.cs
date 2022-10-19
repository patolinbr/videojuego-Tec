using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    public List<Vector2> speeds = new List<Vector2>();

    private List<Material> _materials = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Setting up parallax manager");
        foreach (var parallaxObject in objects)
        {
            Debug.Log(parallaxObject.name);
            _materials.Add(parallaxObject.GetComponent<SpriteRenderer>().material);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            _materials[i].mainTextureOffset += speeds[i] * Time.deltaTime;
        }
    }
}