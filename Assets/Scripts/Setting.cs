using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Setting: MonoBehaviour{
	public static MyLanguage Language;
	public PullDownList LanguageSet;

	void Start()
	{
		InitLanguageSetting ();
	}

	void InitLanguageSetting()
	{
		Language = (MyLanguage)0;
		Dictionary <int,string> LList = new Dictionary<int, string> ();
		LList.Add ((int)MyLanguage.Chinese , "中文");
		LList.Add ((int)MyLanguage.English , "English");
		LanguageSet.Init ((int)Setting.Language, LList);
		LanguageSet.OnValueChange.AddListener (() => Language = (MyLanguage)LanguageSet.GetValue ());
	}
}
