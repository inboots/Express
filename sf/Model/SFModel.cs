using System;
using System.Collections.Generic;
using System.Text;


public class SFModel
{
    private string _nu;

    public string Nu
    {
        get { return _nu; }
        set { _nu = value; }
    }
    private string _message;

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }
    private string _ischeck;

    public string Ischeck
    {
        get { return _ischeck; }
        set { _ischeck = value; }
    }
    private string _com;

    public string Com
    {
        get { return _com; }
        set { _com = value; }
    }
    private string _updatetime;

    public string Updatetime
    {
        get { return _updatetime; }
        set { _updatetime = value; }
    }
    private string _status;

    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    private string _condition;

    public string Condition
    {
        get { return _condition; }
        set { _condition = value; }
    }

    private List<Data> _data;

    public List<Data> Data
    {
        get { return _data; }
        set { _data = value; }
    }
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

}

