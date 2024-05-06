using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour {

    private bool isFirstUpdate = true;
    [SerializeField] private InfoImageLoader infoImageLoader;
    private void Awake() {
        
    }
    private void Start() {
        if (AudioManager.instance != null) {
            AudioManager.instance.Play("Liminality");
        }
    }
    private void Update() {
        if (isFirstUpdate) {
            isFirstUpdate = false;
            Loader.LoaderCallback();
            infoImageLoader.SetImage(Loader.loaderMetaData().ID);
        }
        if (Input.GetKeyDown(KeyCode.Space)||Input.touchCount > 0)
        {
            LoadLevel();
        }
    }
    public void LoadLevel()
    {
        Loader.isReady = true;
    }
}
