using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class NewBehaviourScript : MonoBehaviour
{
    string message;

    public string[] data_s= { "",""};
    public float xPos;
    public float pitch;
    private float temp,temp1;
    SerialPort sp = new SerialPort("COM4", 9600);
    public float range = 1000;
    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        message = sp.ReadLine();
        data_s = message.Split(new string[] { "," }, System.StringSplitOptions.None);
        if (data_s.Length > 1)
        {
            xPos = int.Parse(data_s[0]);
            pitch = int.Parse(data_s[1]);
            temp = xPos;
            temp1 = pitch;
        }
        }

    // Update is called once per frame
    void Update()
    {
        
        
        if (sp.IsOpen)
        {
            try
            {
                
                message = sp.ReadLine();
                data_s = message.Split(new string[] { "," }, System.StringSplitOptions.None); 
                
                
                
            }
            catch (System.Exception)
            {
            }
            if(data_s.Length>1)
            {
                xPos = int.Parse(data_s[0]);
                pitch = int.Parse(data_s[1]);

                if (Mathf.Abs(temp - xPos) < 30 && Mathf.Abs(temp - xPos) > 3 ) {
                    temp = xPos;

                    transform.position = new Vector3(xPos, 0, 0); }
                if (Mathf.Abs(temp1 - pitch) < 30 && Mathf.Abs(temp1 - pitch) > 3)
                {
                    temp1 = pitch;
                    transform.Rotate(Vector3.up, pitch*Time.deltaTime);
                    
                }

            }
            
               
        }

    }
}
