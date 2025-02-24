using UnityEngine;
using UnityEngine.UI;

public class CreditScene : MonoBehaviour
{
    public float scrollSpeed = 40f;

    private RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
