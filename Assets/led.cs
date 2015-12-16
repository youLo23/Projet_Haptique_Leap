using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class led : MonoBehaviour {
	public SerialPort serial = new SerialPort ("COM3", 9600);
	private bool lightState = false;
	public GameObject light = null;
	public AudioClip clip;
	public void OnMouseDown(){
		if (serial.IsOpen == false)
						serial.Open ();
		if (lightState == false) {
						serial.Write ("A");
						lightState = true;
			if(light != null && light.GetComponent<Light>() != null){
				light.GetComponent<Light>().enabled = lightState;
				light.GetComponent<AudioSource>().PlayOneShot(clip);
			}
				} else {
						
						serial.Write ("a");
						lightState = false;
			if(light != null && light.GetComponent<Light>() != null){
				light.GetComponent<Light>().enabled = lightState;
				light.GetComponent<AudioSource>().PlayOneShot(clip);
			}
				}


	}


	
}
