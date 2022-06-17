using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    public bool _isDecreasing;
    [SerializeField] float _decelerationFactor;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
       /* Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;*/
    }

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if(_isDecreasing)
        {
            DecreaseParalax();
            if(parallaxEffectMultiplier.x <0)
            {
                parallaxEffectMultiplier.x = 0;
                parallaxEffectMultiplier.y = 0;
            }
        }
    }

    public void DecreaseParalax()
    {
        parallaxEffectMultiplier.x -= Time.deltaTime * _decelerationFactor;
        //parallaxEffectMultiplier.y -= Time.deltaTime * _decelerationFactor;

    }
}
