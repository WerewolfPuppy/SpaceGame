using UnityEngine;
using System.Collections;
using System.IO.Ports;


	/// <summary>
	/// Controller.cs
	/// 
	/// This script handles player 1 and 2's movement.
	/// Read quaternions "Player1" and "Player2" to get analog stick values.
	/// </summary>


public class controller : MonoBehaviour {
	
	public string com = "COM3";
	SerialPort stream = new SerialPort();
	private string input;
	private int xVal;
	private int yVal;
	private int aVal;
	private int bVal;
	public Quaternion Player1;
	public Quaternion Player2;
	
	
	// Use this for initialization
	void Start () {
		Debug.Log("Opening serial stream on "+com+".");
		stream = new SerialPort(com, 9600);
		stream.Open();
		stream.ReadTimeout = 1;
	}
	
	void FixedUpdate () {
		try {
			for(;;) {				
				input = stream.ReadLine().ToUpper(); // Start reading the serial stream.
				
				if(input.Contains("X")) {
					input = input.Remove(0, 1); // Removes first character in the string.
					xVal = int.Parse(input);	// Parses string to int.
				}
				
				if(input.Contains("Y")) {
					input = input.Remove(0, 1);
					yVal = int.Parse(input);
				}
				
				if(input.Contains("A")) {
					input = input.Remove(0, 1);
					aVal = int.Parse(input);
				}
				
				if(input.Contains("B")) {
					input = input.Remove(0, 1);
					bVal = int.Parse(input);
				}
			}
		}
		catch(System.Exception e){}
		Player1 = new Quaternion(xVal, 0, yVal, 0);	// 1st Players movement coords.
		Player2 = new Quaternion(aVal, 0, bVal, 0);	// 2nd Players movement coords.
	}
}
