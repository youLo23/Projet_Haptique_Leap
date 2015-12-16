using UnityEngine;
using System.Collections;
using Leap;
using System.IO.Ports;


public class CollisionID : MonoBehaviour {

	private SerialPort serial = null;// = new SerialPort ("COM3", 9600);
	public bool ledState = true;

	void Start(){
		//serial = new SerialPort("COM3",9600);
		if (serial == null)
			Debug.Log ("pas ouvert port serie");
		//serial.Open ();
	}


    void OnTriggerEnter(Collider other) {
        Debug.Log ("Collision Trigger Event " + other);
        FingerModel finger = other.GetComponentInParent<FingerModel>();
	    if(finger){
	        //Debug.Log ("Finger " + finger.fingerType);
			//Debug.Log(serial.PortName);
			/*if(serial.IsOpen==false){
				serial.Open();
			}
			Debug.Log(ledState);
			ledState = !ledState;
			if(ledState){
				serial.Write("A");
			}
			else{
				serial.Write("B");
			}*/
        }
    }
	
	void OnCollisionEnter(Collision collision) 
	{
		FingerModel finger = collision.gameObject.GetComponentInParent<FingerModel>();


		if(finger){
			HandModel hand = finger.GetComponentInParent<HandModel> ();
			
			bool leftHand = hand.GetLeapHand ().IsLeft;
			Debug.Log ("Finger collision " + finger.fingerType);
			if (leftHand) {
				Debug.Log ("Main Gauche");
			} else {
				Debug.Log ("Main droite");
			}

			/*if(serial.IsOpen==false){
				serial.Open();
			}

			Debug.Log(ledState);
			ledState = !ledState;
			if(ledState){
				serial.Write("A");
			}
			else{
				serial.Write("B");
			}*/

		}
	}
}