using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SignType
{
    mage,//법사
    warrior,//전사
    thief,//도적
    archer//궁수
}
[System.Serializable]
public class Sign
{
    public string name;     //이름
    public int value;       //존재유무
    public string comment;     //설명
    public SignType type;   //어떤 캐릭터에 해당하는가
    public float influence; //영향력(확률)
    public float power;     //넉백하는 힘
    public float damage;    //데미지
    public float range;     //사정거리
    public Sprite image;

    public Sign(string _name, int _value, string _comment, SignType _type, float _influence,
        float _power, float _damage, float _range,Sprite _image)
    {
        name = _name;
        value = _value;
        comment = _comment;
        type = _type;
        influence = _influence;
        power = _power;
        damage = _damage;
        range = _range;
        image = _image;
    }
};
