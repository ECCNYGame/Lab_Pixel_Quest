using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour
{
    public string nextLevel = "Level_2";
    private Rigidbody2D _rigidbody2D;
    public int speed = 5;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(xInput * speed, _rigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _spriteRenderer.color = Color.red;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _spriteRenderer.color = Color.blue;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _spriteRenderer.color = Color.green;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Death":
                {
                    string thisLevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
        }
    }
}