using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using LitJson;

public class TransManager{

	public static string LangDeffult="cn";
	public JsonData data = JsonMapper.ToObject (File.ReadAllText ("Assets/Editor/Desc/Translate.desc"));
	Regex r;
	static Regex i=new Regex(@"\?(\w*)\?");

	public TransManager(string ori)
	{

	}

	public string getTranslate(string TransMessage,string Language,Dictionary<string,string> TransParams=null)
	{
		if (i.IsMatch (TransMessage)) 
		{
			return i.Match(TransMessage).Groups[1].ToString ();
		}
		string input = data[TransMessage][Language].ToString();
		if(TransParams!=null)
		foreach (var ele in TransParams) {
			string s=@"'"+ele.Key+@"'";
			r=new Regex(s);
			string temp=getTranslate (ele.Value,Language);
			input=r.Replace (input,temp);
		}
		return input;
	}
}
