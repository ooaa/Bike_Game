using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



[Serializable]
public class PlayerData{
    public int sushi;
    public int villagers;
    public int distance;

    public int sushi_collected
    {
        get { return sushi; }
        set { sushi = value; }
    }

    public int villiagers_hit
    {
        get { return villagers; }
        set { villagers = value; }
    }
    public int distance_Travelled
    {
        get { return distance; }
        set { distance = value; }
    }
    
    public String toString()
    {
        return "Sushi-All: " + sushi + "; Distance-All " + distance + ";Villagers-all: " + villagers + ";";
    }

}
