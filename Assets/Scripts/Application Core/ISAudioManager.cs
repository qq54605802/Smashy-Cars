using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Audio Manager for Gravity
/// 
/// Audio Manager was initally write for ISGravity, revised for Ball Crashes,
/// Including many new features.
/// 
/// </summary>

public class ISAudioManager : MonoBehaviour {

	static private AudioObject[] audioObject;
	
	static public ISAudioManager audioManager;
	
	static private Transform cam;
	
	public float minFallOffRange=10;

	public AudioMixerGroup notificationGroup;
	public AudioClip[] musicList;
	public AudioMixerGroup musicGroup;
	public bool playMusic=true;
	public bool shuffle=false;
	private int currentTrackID=0;
	private AudioSource musicSource;
	private AudioSource notificationSource;

	public AudioMixerGroup defaultGroup;

	public AudioClip gameStartSound;
	public AudioClip gameWonSound;
	public AudioClip gameLostSound;
	
	public AudioClip actionFailedSound;
	
	static private ISAudioManager self;
	//private int musicThatPlayNow = -1; //-1 if there isn't any music need to play;
	

	
	void Awake(){
		//Init();
		self=this;
		
		cam=Camera.main.transform;

		GameObject notificationObj=new GameObject();
		notificationObj.name="NotificationSource";
		notificationObj.transform.position=cam.position;
		notificationObj.transform.parent=cam;
		notificationSource=notificationObj.AddComponent<AudioSource>();
		notificationSource.loop=false;
		notificationSource.playOnAwake=false;
		notificationSource.ignoreListenerVolume=true;
		notificationSource.outputAudioMixerGroup = notificationGroup;

		if(playMusic && musicList!=null && musicList.Length>0){
			GameObject musicObj=new GameObject();
			musicObj.name="MusicSource";
			musicObj.transform.position=cam.position;
			musicObj.transform.parent=cam;
			musicSource=musicObj.AddComponent<AudioSource>();
			musicSource.loop=false;
			musicSource.playOnAwake=false;
			
			musicSource.ignoreListenerVolume=true;
			musicSource.outputAudioMixerGroup = musicGroup;
			
			StartCoroutine(MusicRoutine());
		}
		
		audioObject=new AudioObject[30];
		for(int i=0; i<audioObject.Length; i++){
			GameObject obj=new GameObject();
			obj.name="AudioSource";
			
			AudioSource src=obj.AddComponent<AudioSource>();
			src.playOnAwake=false;
			src.loop=false;
			src.minDistance=minFallOffRange;
			src.outputAudioMixerGroup = defaultGroup;

			Transform t=obj.transform;
			t.parent=self.transform;
			
			audioObject[i]=new AudioObject(src, t);
		}
		
		AudioListener.volume=0.8f;
		
		if(audioManager==null) audioManager=this;
	}
	
	static public void Init(){
		if(audioManager==null){
			GameObject objParent=new GameObject();
			objParent.name="AudioManager";
			audioManager=objParent.AddComponent<ISAudioManager>();
		}		
	}
	
	public IEnumerator MusicRoutine(){
		while(true){
				if(shuffle) musicSource.clip=musicList[Random.Range(0, musicList.Length)];
				else{
					musicSource.clip=musicList[currentTrackID];
					currentTrackID+=1;
					if(currentTrackID==musicList.Length) currentTrackID=0;
				}
			
				musicSource.Play();
			
				yield return new WaitForSeconds(musicSource.clip.length);

		}
	}

	//Get the free audioObject.
	static private int GetUnusedAudioObject(){
		for(int i=0; i<audioObject.Length; i++){
			if(!audioObject[i].inUse){
				return i;
			}
		}
		for(int i=0; i<audioObject.Length; i++){
			if(!audioObject[i].isImportant){
				return i;
			}
		}

		return 0;
	}

	static public void PlayNotificationSound(AudioClip clip){
		//ISAudioManager.PlaySound (clip, Vector3.zero, audioManager.notificationGroup, 1f, true);
		audioManager.notificationSource.clip = clip;
		audioManager.notificationSource.Play ();
	}

	static public void PlaySound(AudioClip clip, Vector3 pos, AudioMixerGroup group, float volume, bool isImportant){
		if(audioManager==null) Init();
		
		int ID=GetUnusedAudioObject();
		
		if(ID == -1) return;
		
		audioObject[ID].inUse=true;
		
		audioObject[ID].thisT.position=pos;
		audioObject [ID].isImportant = isImportant;
		audioObject[ID].source.clip=clip;
		audioObject[ID].source.outputAudioMixerGroup = group;
		audioObject[ID].source.volume = volume;
		audioObject[ID].source.Play();
		
		float duration=audioObject[ID].source.clip.length;
		
		audioManager.StartCoroutine(audioManager.ClearAudioObject(ID, duration));
	}

	static public void PlaySound(AudioClip clip, Vector3 pos, bool isImportant){
		if(audioManager==null) Init();
		
		int ID=GetUnusedAudioObject();
		
		if(ID == -1) return;
		
		audioObject[ID].inUse=true;
		audioObject [ID].isImportant = isImportant;
		audioObject[ID].thisT.position=pos;
		audioObject[ID].source.clip=clip;
		audioObject[ID].source.Play();
		
		float duration=audioObject[ID].source.clip.length;
		
		audioManager.StartCoroutine(audioManager.ClearAudioObject(ID, duration));
		
	}

	static public AudioSource CreateNewAudioObject(AudioClip clip, bool playNow, ISAudioManagerAudioType type){
		GameObject newObj = new GameObject("Audio Object(ISAudioManager)");
		newObj.transform.parent = cam;
		newObj.transform.localPosition = Vector3.zero;
		AudioSource audio = newObj.AddComponent<AudioSource> ();
		audio.clip = clip;
		audio.loop = true;
		switch (type) {
		case ISAudioManagerAudioType.Default:
			audio.outputAudioMixerGroup = self.defaultGroup;
			break;
		case ISAudioManagerAudioType.Music:
			audio.outputAudioMixerGroup = self.musicGroup;
			break;
		case ISAudioManagerAudioType.Notification:
			audio.outputAudioMixerGroup = self.notificationGroup;
			break;
		}

		if(playNow) audio.Play ();
		return audio;
	}

	static public void PlaySound(AudioClip clip, bool isImportant){
		if(audioManager==null) Init();
		
		int ID=GetUnusedAudioObject();
		if(ID == -1) return;
		audioObject[ID].inUse=true;
		audioObject [ID].isImportant = isImportant;
		audioObject[ID].thisT.position = Vector3.zero;
		audioObject[ID].source.clip=clip;
		audioObject[ID].source.Play();
		
		float duration=audioObject[ID].source.clip.length;
		
		audioManager.StartCoroutine(audioManager.ClearAudioObject(ID, duration));
	}

	static IEnumerator SoundRoutine2D(int ID, float duration){
		while(duration>0){
			audioObject[ID].thisT.position=cam.position;
			yield return null;
		}

		audioManager.StartCoroutine(audioManager.ClearAudioObject(ID, 0));
	}

	private IEnumerator ClearAudioObject(int ID, float duration){
		yield return new WaitForSeconds(duration);
		
		audioObject[ID].inUse=false;
		audioObject [ID].isImportant = false;
		audioObject [ID].source.outputAudioMixerGroup = defaultGroup;
		audioObject [ID].source.volume = 1f;
	}
	
	static public void SetSFXVolume(float val){
		AudioListener.volume=val;
	}
	
	static public void SetMusicVolume(float val){
		//Debug.Log("HEHE"+audioManager.musicSource.volume);
		if(audioManager  && audioManager.musicSource){
			audioManager.musicSource.volume=val;
		}
	}
	
}

public enum ISAudioManagerAudioType{Default, Notification, Music}

[System.Serializable]
public class AudioObject{
	public AudioSource source;
	public bool inUse=false;
	public bool isImportant = false;
	public Transform thisT;
	
	public AudioObject(AudioSource src, Transform t){
		source=src;
		thisT=t;
	}
}

[System.Serializable]
public class LoopAudioPlayer{
	public AudioSource source;
	public int instanceID;
}