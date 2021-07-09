using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IMove
{

    [SerializeField]
    private string m_name;
    [SerializeField]
    private string m_type;
    [SerializeField]
    private int m_uses;

    public Move(string name, string type, int uses)
    {

        this.m_Name = name;
        this.m_Type = type;
        this.m_Uses = uses;

    }

    public string m_Name
    {
        get { return name; }
        set { name = value; }
    }

    public string m_Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public int m_Uses
    {

        get { return m_uses; }
        set { m_uses = value; }

    }

}
