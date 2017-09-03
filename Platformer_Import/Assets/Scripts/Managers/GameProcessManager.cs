using UnityEngine;
using System.Collections;

public class GameProcessManager : MonoBehaviour 
{

	private TimeManager _timeManager;
	public TimeManager timeManager
	{
		get
		{
			return _timeManager;
		}
	}

    private PopUpAnimation _popAnim;
    private HeroMove _hero;
	private GlobalController _moveControll;
	private JsonFileSaveManager _saveInFileManager;
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

		_saveInFileManager = GameObject.FindObjectOfType<JsonFileSaveManager> ();
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
        ScoreManager.Instance.TekScore = 0;
        _moveControll.enabled = true;
        _popAnim.HideGameOverPopUp();

    }

    public void GameOver()
    {
		_saveInFileManager.SaveProgress ();
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
