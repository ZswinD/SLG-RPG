using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Land:EditorWindow
{	
	static List<bool> fold=new List<bool>();
	static List<bool> innerfold=new List<bool>();
	public static Dictionary<int,LandForm> LandFormDict;
	public static Dictionary<int,LandEffect> LandEffectDict;
	[MenuItem("HexGrids/Land")]
	static void ShowLand(){
		if (LandFormDict != LandXml.LandFormDict) {
			LandXml.LoadLandFile ();
			LandFormDict=LandXml.LandFormDict;	
		}
		if (LandEffectDict != LandXml.LandEffectDict) {
			LandXml.LoadLandEffect();
			LandEffectDict=LandXml.LandEffectDict;
		}
		Rect wr = new Rect (0, 0, 200, 300);
		Land window = (Land)EditorWindow.GetWindowWithRect <Land> (wr, false, "Lands");
		window.Show ();
		for (int i=0; i<LandFormDict.Count; i++) 
		{
			fold.Add (false);
			innerfold.Add (false);
		}
	}
	void OnGUI()
	{
		if (LandFormDict == null)
						ShowLand ();
		EditorGUILayout.LabelField ("Land");
		int count = 0;
		foreach (LandForm lf in LandFormDict.Values) 
		{
			fold[count]=EditorGUILayout.Foldout(fold[count],lf.Name);
			if(fold[count])
			{
				List<bool> efold=new List<bool>(lf.Effect.Count);
				EditorGUILayout.BeginVertical ();
				EditorGUILayout.LabelField ("ID",lf.ID.ToString ());
				EditorGUILayout.LabelField("Name",lf.Name);
				innerfold[count]=EditorGUILayout.Foldout (innerfold[count],"Effects");
				if(innerfold[count])
				{
					int Ecount=0;
					Dictionary<int,float> lfEffect=new Dictionary<int, float>(lf.Effect);
					foreach(int eID in lf.Effect.Keys)
					{
						//efold[Ecount]=EditorGUILayout.Foldout(efold[Ecount],"Effect "+Ecount.ToString());
						//if(efold[Ecount]){
						EditorGUILayout.LabelField("Effect Name",LandEffectDict[eID].Name);
						EditorGUILayout.LabelField("Effect Key",LandEffectDict[eID].Key);
						lfEffect[eID]=EditorGUILayout.FloatField("Effect Value",lfEffect[eID]);
						Ecount++;
						//}
					}
					lf.Effect =lfEffect;
				}
				EditorGUILayout.EndVertical ();
			}
			count++;
		}
	}
}