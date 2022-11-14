using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private int _health; // this
    public int Health {
        get {
            return _health;
        }
        set{
           _health = value; 
        }
    }
    
    private int _power;
    public int Power {
        get {
            return _power;
        }
        set {
            _power = value;
        }
    }
  
    private string _name;
    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }

    public Player() { }
    
    public Player(int health, int power, string name){ 
        
        // this.health = health > this.health reffer to the health in the class 
        Health = health;
        Power = power;
        Name = name;        
    }

    public void Attack(){
        Debug.Log(_name + " is attacking!!!");
    }
    
    public void Info(){

        Debug.Log("Health is: " + Health);
        Debug.Log("Power is: " + Power);
        Debug.Log("Name is: " + Name);
    }
}
