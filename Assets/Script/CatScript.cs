using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;

[System.Serializable]
public class Bar { 
    public float value, maxValue; 
    public void AddValue(float adding)
    {
        value += adding;

        if(value > maxValue)
        {
            value = maxValue;
        }

        if(value < 0)
        {
            value = 0;
        }
    }
}

public class CatScript : MonoBehaviour
{
    public Bar health, eat, sleep, happiness, age;//todo;
    public string name;

    XElement game, player;
    List<XAttribute> Atributs = new List<XAttribute>();

    public static GameObject PlayerCat;
    public void Open()
    {
        game = XDocument.Parse(File.ReadAllText("ARGameBase.xml")).Element("Game");
        name = game.Element("Dannie").Attribute("name").Value.ToString();
        health.value = float.Parse(game.Element("Dannie").Attribute("health").Value);
        eat.value = float.Parse(game.Element("Dannie").Attribute("eat").Value);
        sleep.value = float.Parse(game.Element("Dannie").Attribute("sleep").Value);
        happiness.value = float.Parse(game.Element("Dannie").Attribute("happiness").Value);
        Debug.Log("open");
    }

    public void Save()
    {
        game = new XElement("Game");
        Atributs.Add(new XAttribute("health", health.value));
        Atributs.Add(new XAttribute("eat", eat.value));
        Atributs.Add(new XAttribute("sleep", sleep.value));
        Atributs.Add(new XAttribute("happiness", happiness.value));
        Atributs.Add(new XAttribute("name", name));
        player = new XElement("Dannie", "-", Atributs);
        game.Add(player); Atributs.Clear();
        File.WriteAllText("ARGameBase.xml", game.ToString());
        Debug.Log("save");
    }
}
