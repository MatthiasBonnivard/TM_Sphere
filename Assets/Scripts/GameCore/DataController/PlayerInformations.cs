using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerInformations
{
    protected string login = "";
    protected string pwd = "";
    protected int age = 0;
    protected enum Genre{
        FEMININ,
        MASCULIN
    }
    private Genre sexe = Genre.MASCULIN;

    public PlayerInformations()
    {
    }

    public void SetPlayerInformations(string login, string pwd)
    {
        this.login = login;
        this.pwd = pwd;
    }

    public string GetLogin()
    {
        return this.login;
    }
}
