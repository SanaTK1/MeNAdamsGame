using UnityEngine;

public class Example_GameObject : MonoBehaviour
  {
      private void Start()
      {
          GameObject myExampleGO = new GameObject("myExampleGO", typeof(AudioSource));
      }
  }
