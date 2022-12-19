using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    Color32 carColorWithoutPackage;
    Color32 carColorWithPackage;
    [SerializeField] float destroyDelay = 0.5f;
    GameObject package;

    SpriteRenderer spriteRenderer;

    void Start() {
        // carColorWithPackage = hexToColor("43E72A");
        // carColorWithoutPackage = hexToColor("2AE742");
        carColorWithPackage = hexToColor("FF00FF");
        carColorWithoutPackage = hexToColor("00FF00");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = carColorWithoutPackage;
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log(other);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            Debug.Log(other.tag + " Triggered");
            hasPackage = true;
            spriteRenderer.color = carColorWithPackage;
            this.package = other.gameObject;
            this.package.SetActive(false);
            // Destroy(other.gameObject, destroyDelay);
        }
        if(other.tag == "Customer" && hasPackage) {
            Debug.Log(other.tag + " Triggered");
            hasPackage = false;
            spriteRenderer.color = carColorWithoutPackage;
            this.package.SetActive(true);
        }
        
    }

    public Color hexToColor(string hex)
    {
        hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if(hex.Length == 8){
            a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r,g,b,a);
    }
}
