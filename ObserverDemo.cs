using System;
using System.Collections.Generic;
public interface Observer{
    void Update(float temperature, float humidity);
}
public interface Subject{
    void RegisterObeserver(Observer observer);
    void RemoveObserver(Observer observer);
    void notifyObservers();
}
// concrete class of subject
public class WeatherStation:Subject{
    private List<Observer> observers;
    private float temperature;
    private float humidity;

    public WeatherStation(){
        observers = new List<Observer>();
    }
    public void RegisterObeserver(Observer observer){
        observers.Add(observer);
    }
    public void RemoveObserver(Observer observer){
        observers.Remove(observer);
    }
    public void notifyObservers(){
        foreach(Observer observer in observers){
            observer.Update(temperature,humidity);
        }
    }
    public void setMeasurements(float temperature, float humidity){
        this.temperature = temperature;
        this.humidity = humidity;
        notifyObservers();
    }
}
// concrete class of observer
public class WeatherDisplay:Observer{
    private float temperature;
    private float humidity;
    public void Display(){
        Console.WriteLine($"temperature:{temperature} humidity: {humidity}");
    }
    public void Update(float temperature,float humidity){
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }
}

public class Program{
    public static void Main(string[] args){
        WeatherStation ws = new WeatherStation();
        WeatherDisplay wd = new WeatherDisplay();
        ws.RegisterObeserver(wd);
        ws.setMeasurements(25.5f,65.0f);
        ws.setMeasurements(28.3f,66.9f);
    }
}