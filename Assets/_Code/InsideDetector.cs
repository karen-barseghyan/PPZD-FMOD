using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using FMODUnity;

public class InsideDetector: MonoBehaviour {
  //[SerializeField] AudioMixerSnapshot Outside;
  //[SerializeField] AudioMixerSnapshot Inside;
  //[SerializeField] AudioSource DoorOpen;
  //[SerializeField] AudioSource DoorClose;

  string currentStatus = "outside";
  float currentInsideVolume = 0f;
  float maxInsideVolume = 1.5f;
  float currentOutsideVolume = 1.5f;
  float maxOutsideVolume = 1.5f;

void Start(){
        var vcaInside = RuntimeManager.GetVCA("vca:/inside");
        vcaInside.setVolume(currentInsideVolume);
        var vcaOutside = RuntimeManager.GetVCA("vca:/outside");
        vcaOutside.setVolume(currentOutsideVolume);
}

  void OnTriggerStay(Collider other) {
    Debug.Log("inside");
    currentStatus = "inside";
  }

  void OnTriggerExit(Collider other) {
    Debug.Log("outside");
    currentStatus = "outside";
  }

  void changeVolume() {
    if (currentStatus == "outside"){

Debug.Log("Inside Volume: " + currentInsideVolume + "|||||| Outside Volume: " + currentOutsideVolume);

      if (currentInsideVolume > 0f){
        var vcaInside = RuntimeManager.GetVCA("vca:/inside");
        currentInsideVolume = currentInsideVolume - 0.01F;
        vcaInside.setVolume(currentInsideVolume);
      }

      if (currentOutsideVolume < 1.5f){
        var vcaOutside = RuntimeManager.GetVCA("vca:/outside");
        currentOutsideVolume = currentOutsideVolume + 0.01F;
        vcaOutside.setVolume(currentOutsideVolume);
      }


    }

    if (currentStatus == "inside"){
Debug.Log("Inside Volume: " + currentInsideVolume + "|||||| Outside Volume: " + currentOutsideVolume);
      if (currentOutsideVolume > 0f){
        var vcaOutside = RuntimeManager.GetVCA("vca:/outside");
        currentOutsideVolume = currentOutsideVolume - 0.01F;
        vcaOutside.setVolume(currentOutsideVolume);
      }

      if (currentInsideVolume < 1.5f){
        var vcaInside = RuntimeManager.GetVCA("vca:/inside");
        currentInsideVolume = currentInsideVolume + 0.01F;
        vcaInside.setVolume(currentInsideVolume);
      }




    }
       

  }

  /*
        void changeSnapshot() {
      if (currentStatus == "outside") {
        Outside.TransitionTo(0.01f);
        DoorClose.Play(0);
      }
       
       if (currentStatus == "inside") {
        Inside.TransitionTo(0.01f);
        DoorOpen.Play(0);
      }

    }
  */
  void Update() {
    changeVolume();
    
  Debug.Log(currentStatus);
  }

}