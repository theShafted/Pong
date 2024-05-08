using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _speed;

    public Vector3 _velocity;

    public Vector3 _position;
    public Vector2 _bounds;
    public Vector2 _screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
        
        string server = Random.Range(0, 2) > 1 ? "player" : "opponent";
        Serve(server);

        _bounds = GetComponent<SpriteRenderer>().bounds.size / 2;
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (_position.y >= _screenBounds.y - _bounds.y || _position.y <= -_screenBounds.y + _bounds.y)
        {
            _velocity.y = -_velocity.y;
        }

        _position += _velocity * Time.deltaTime;
        transform.position = _position;
    }

    public void Reset()
    {
        _velocity = Vector2.zero;
        _position = Vector3.zero;
        transform.position = _position;
    }
    public void Serve(string server)
    {
        _velocity.y = Random.Range(-_speed, _speed);

        float vx = Random.Range(_speed/2, _speed);
        _velocity.x = server == "player" ? vx : -vx;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _velocity.x = -_velocity.x;
    }
}
