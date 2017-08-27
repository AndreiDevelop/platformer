using UnityEngine;
using System.Collections;

public class GameProcessManager : MonoBehaviour 
{
    private PopUpAnimation _popAnim;
    private HeroMove _hero;

    private TimeManager _timeManager;
    private ScoreManager _scoreManager;
    private GlobalController _moveControll;

	// Use this for initialization
	void Start () 
    {
        _hero = GameObject.FindWithTag("Hero").GetComponent<HeroMove>();

        //получаем контроллеры
        _moveControll = GameObject.FindObjectOfType<GlobalController>();

        //получаем контроллер анимации поп-апов
        _popAnim = GameObject.FindObjectOfType<PopUpAnimation>();

        //получаем счетчик времени
        _timeManager = GameObject.FindObjectOfType<TimeManager>();

        //получаем менеджер счетчика
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Hero")
        {
            _hero.ResetHeroMoveAndPosition();
            _hero.Freeze(true);
            GameOver();
        }
	}

    #region TimeMethods

    void ResetTime()
    {
        _timeManager.ResetTimeCounter();
    }

    void StopTime()
    {
        _timeManager.StorTimeCounter();
    }

    void ContinueTime()
    {
        _timeManager.ContinueTimeCounter();
    }

    #endregion

    #region StateOfGame

    public void StartGame()
    {
        ResetTime();
        ContinueTime();
        _moveControll.enabled = true;
        _popAnim.HideStartPopUp();
    }

    public void ResetGame()
    {
        _hero.Freeze(false);
         ResetTime();
         ContinueTime();
        _scoreManager.TekScore = 0;
        _moveControll.enabled = true;
        _popAnim.HideGameOverPopUp();

    }

    public void GameOver()
    {
        StopTime();
        _moveControll.enabled = false;
        _popAnim.ShowGameOverPopUp();
    }

    #endregion

    public void ReloadLevel()
    {
        Application.LoadLevel(0);
    }
}
