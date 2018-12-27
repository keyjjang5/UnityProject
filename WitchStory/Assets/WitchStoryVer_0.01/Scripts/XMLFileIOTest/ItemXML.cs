using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml.Serialization;


//데이터만 존재해야함
//상속 X
public class ItemXML
{
    [XmlAttribute("Name")]
    public string _name;

    [XmlAttribute("TexturePath")]
    public string textureName;

    public int gridCount;
}
