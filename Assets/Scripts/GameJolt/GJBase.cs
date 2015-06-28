using System;
using UnityEngine;
using System.Collections;

public class GJBase : MonoBehaviour {

	public int gameID;  
	public string privateKey;
	string userName;
	string userToken;

	static GJBase _instance;
	private static object _lock = new object();
	
	public static bool isActive { 
		get { 
			return _instance != null; 
		} 
	}
	
	private static bool applicationIsQuitting = false;
	public void OnDestroy () {
		applicationIsQuitting = true;
	}
	
	public static GJBase instance
	{
		get
		{
			if (applicationIsQuitting) {
				return null;
			}
			lock(_lock)
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType(typeof(GJBase)) as GJBase;
					
					if (_instance == null)
					{
						GameObject go = new GameObject();
						_instance = go.AddComponent<GJBase>();
						go.name = "(singleton) "+typeof(GJBase).ToString();
						DontDestroyOnLoad(go);
					}
				}
				return _instance;
			}
		}
	}

	void Awake () {
		DontDestroyOnLoad (gameObject);
		GJAPI.Init (gameID, privateKey);
	}

#if UNITY_EDITOR

	void Start () {
		userName = "tonypai";
		userToken = "c6535e";
		GJAPI.Users.Verify(userName, userToken);
	}

	void OnEnable () {
		GJAPI.Users.VerifyCallback += OnVerifyUser;
	}
	void OnDisable () {  
		if (GJAPI.Instance != null)
		{
			GJAPI.Users.VerifyCallback -= OnVerifyUser;  
		}  
	}
	
	void OnVerifyUser ( bool success ) {}

	public void AddScore (int val) {

		uint score = (uint)val;
		GJAPI.Scores.Add ("Crash " + score + " times", score, 78742, "");
	}

	public void UnlockTrophy (int val) {

		uint trophyId = (uint)0;
		if (val >= 10)
			trophyId = (uint)33124;
		else if (val >= 5)
			trophyId = (uint)33123;
		else if (val >= 1)
			trophyId = (uint)33122;
		
		GJAPI.Trophies.Add (trophyId);
//		GJAPIHelper.Trophies.ShowTrophyUnlockNotification(trophyId);
	}

#elif UNITY_WEBPLAYER
	private bool m_isGuest = true;

	void Start () {
		Application.ExternalCall ("GJAPI_AuthUser", gameObject.name, "CheckIfLogin");
	}
	
	public void CheckIfLogin (string response)
	{
		string[] splittedResponse = response.Split (':');

		if (splittedResponse.Length < 2) {
			m_isGuest = true;
			return;
		} else {
			m_isGuest = false;
		}

		userName = splittedResponse [0];
		userToken = splittedResponse [1];
		GJAPI.Users.Verify(userName, userToken);
	}

	void OnEnable () {
		GJAPI.Users.VerifyCallback += OnVerifyUser;
		GJAPI.Scores.AddCallback += OnAddScore;
		GJAPI.Trophies.AddCallback += OnAddTrophy;
	}
	
	void OnDisable () {  
		if (GJAPI.Instance != null)
		{
			GJAPI.Users.VerifyCallback -= OnVerifyUser;  
			GJAPI.Scores.AddCallback -= OnAddScore;
			GJAPI.Trophies.AddCallback -= OnAddTrophy;
		}  
	}

	void OnVerifyUser ( bool success ) {}
	void OnAddScore (bool success) {}
	void OnAddTrophy (bool success) {}

	public void AddScore (int val) {

		if (m_isGuest)
			return;

		uint score = (uint)val;
		GJAPI.Scores.Add ("Crash " + score + " times", score, 78742, "");
	}

	public void UnlockTrophy (int val) {

		if (m_isGuest)
			return;

		uint trophyId = (uint)0;
		if (val >= 10)
			trophyId = (uint)33124;
		else if (val >= 5)
			trophyId = (uint)33123;
		else if (val >= 1)
			trophyId = (uint)33122;

		GJAPI.Trophies.Add (trophyId);
//		GJAPIHelper.Trophies.ShowTrophyUnlockNotification(trophyId);
	}
#endif
}
