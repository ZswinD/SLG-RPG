using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Linq;

public class SimpleWarTest : MonoBehaviour {

	public SimpleWarMap map=new SimpleWarMap ("Test");
	public Character player = Character.NormalChar;
	public Button startbutton;
	public Button gamesetting;
	public Button warsetting;
	public GameObject go_GameSetting;
	public GameObject go_WarSetting;
	public InSimpleWarManager playerManager;
	public InSimpleWarManager enemyManager;
	public Text InfoText;
	public Image me;
	public SimpleWar mywar=new SimpleWar();
	public SimpleWarManager myManager;
	public SimpleWarData data;
	int LanguageValue=0;
	public bool IfWarStarted;
	public bool Stop;

	// Use this for initialization
	void Start () {
		myManager = GameObject.FindObjectOfType<SimpleWarManager> ();
		player.Name = "ozy";
		playerManager.Init (player);
		data =new SimpleWarData(map, player);
		startbutton.onClick.AddListener (()=>{StopWar(); go_GameSetting.SetActive (false);go_WarSetting.SetActive (false);});
		gamesetting.onClick.AddListener (() => go_GameSetting.SetActive (!go_GameSetting.activeSelf));
		IfWarStarted = true;
		warsetting.onClick.AddListener (() => go_WarSetting.SetActive (!go_WarSetting.activeSelf));

	}

	void StopWar()
	{
		if (!mywar.Stop) 
		{
			enemyManager.me=null;
			mywar.Stop = true;
			enemyManager.Clear ();
			playerManager.Init (player);
			startbutton.GetComponentInChildren<Text>().text="Start";
		}
		else {
			mywar.Stop=false;
			IfWarStarted=true;
			startbutton.GetComponentInChildren<Text>().text="Pause";
		}
	}

	// Update is called once per frame
	void Update () {
		if(IfWarStarted) {
			playerManager.Init (player);
			IfWarStarted=false;
			StartCoroutine(mywar.DoSimpleWar (data));
		}
	}
}
