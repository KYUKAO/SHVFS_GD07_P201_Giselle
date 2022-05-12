using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSelfLearn : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
class Cooler
{
    public Cooler(float temperature) { Temperature = temperature; }
    public float Temperature { get; set; }
    public void OnTemperatureChanged(float newTemperature)
    {
        if (newTemperature > Temperature)
            System.Console.WriteLine("Cooler: On");
        else
            System.Console.WriteLine("Cooler: Off");
    }
}
class Heater
{
    public Heater(float temperature) { Temperature = temperature; }
    public float Temperature { get; set; }
    public void OnTemperatureChanged(float newTemperature)
    {
        if (newTemperature < Temperature)
            System.Console.WriteLine("Heater: On");
        else
            System.Console.WriteLine("Heater: Off");
    }
}
