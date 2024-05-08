using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentPaddle : MonoBehaviour
{
    [SerializeField] private int _moveSpeed;
    [SerializeField] private Ball _ball;

    private Vector3 _position;
    private Vector2 _screenBounds;
    private Vector2 _bounds;

    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _bounds = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball._velocity.x > 0)
        {
            int input = _ball._position.y > _position.y ? 1 : -1;

            _position.y += input * _moveSpeed * Time.deltaTime;
            transform.position = _position;
        }
    }
}
