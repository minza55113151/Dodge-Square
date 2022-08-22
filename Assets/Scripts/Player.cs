using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

    public float speed;
    
    public Vector2 movement;
    private Rigidbody2D rb;

    public bool isImmortal = false;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        PlayerInput();
    }
    private void PlayerInput()
    {
        movement = JoyStickManager.instance.joystickVec;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    public void Revive()
    {
        isImmortal = true;
        StartCoroutine(PlayerImmortal());
    }
    public IEnumerator PlayerImmortal()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        Color color = sr.color;
        sr.color = new Color(color.r, color.g, color.b, color.a * 0.5f);
        yield return new WaitForSeconds(5f);
        sr.color = new Color(color.r, color.g, color.b, color.a * 2f);
        isImmortal = false;
    }
    
}
