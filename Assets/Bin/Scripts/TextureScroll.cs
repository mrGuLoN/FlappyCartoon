using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{ 

    private Renderer _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void Scroll(float speedScrollTexture, float timeDelta)
    {       
        _material.material.mainTextureOffset += new Vector2(speedScrollTexture * timeDelta, 0);
    }
}
