using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    
    [SerializeField] private TMP_Text _playerText;
    [SerializeField] private TMP_Text _opponentText;

    private int _playerScore;
    private int _opponentScore;
    private string _gameState;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState == "play")
        {
            PlayState();
        }
        else if (_gameState == "player" || _gameState == "opponent")
        {
            ServeState();
        }
        else
        {
            GameOverState();
        }

    }

    private void PlayState()
    {
        _ball.OnUpdate();

        if (_ball._position.x > _ball._screenBounds.x - _ball._bounds.x)
        {
            _playerScore++;
            _playerText.text = _playerScore.ToString();

            _gameState = _playerScore == 5 ? "win" : "opponent";
        }

        if (_ball._position.x < -_ball._screenBounds.x + _ball._bounds.x)
        {
            _opponentScore++;
            _opponentText.text = _opponentScore.ToString();

            _gameState = _opponentScore == 5 ? "lose" : "player";
        }
    }
    private void ServeState()
    {
        _ball.Reset();

        if (Input.GetKey("return"))
        {
            _ball.Serve(_gameState);

            _gameState = "play";
        }
    }
    private void GameOverState()
    {
        _playerText.text = "YOU";
        _opponentText.text = _playerScore == 5 ? "WIN!" : "LOST";

        if (Input.GetKey("return")) Reset();
    }
    private void Reset()
    {
        _playerScore = 0;
        _opponentScore = 0;

        _playerText.text = "0";
        _opponentText.text = "0";

        _gameState = Random.Range(0, 2) > 1 ? "player" : "opponent";
    }
}
