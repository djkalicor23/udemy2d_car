using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    Color32 carColorWithoutPackage;
    Color32 carColorWithPackage;
    GameObject package;

    SpriteRenderer spriteRenderer;

    void Start() {
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
            hasPackage = true;
            spriteRenderer.color = carColorWithPackage;
            package = other.gameObject;
            package.SetActive(false);
        }
        
        if(other.tag == "Customer" && hasPackage) {
            hasPackage = false;
            spriteRenderer.color = carColorWithoutPackage;

            float xRandom = Random.Range(-1f, 1f);
            float yRandom = Random.Range(-1f, 1f);
            package.transform.position = new Vector3(xRandom < 0 ? -11 : 11, yRandom < 0 ? -7 : 11, 0);
            package.SetActive(true);
        }
        
    }

    static Color hexToColor(string hex)
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
