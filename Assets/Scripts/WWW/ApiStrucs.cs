using System;

[Serializable]
public struct CredentialsData
{
    public string userName;
    public string password;

    public CredentialsData(string userName, string password)
    {
        this.userName = userName;
        this.password = password;
    }
}

[Serializable]
public struct UpdateData
{
    public string userName;
    public string field;
    public string value;

    public UpdateData(string userName, string field, string value)
    {
        this.userName = userName;
        this.field = field;
        this.value = value;
    }
    
    public UpdateData(string field, string value)
    {
        userName = String.Empty;
        this.field = field;
        this.value = value;
    }
}

[Serializable]
public struct SkillsData
{
    public bool fireArrow;
    public bool frozenArrow;
    public bool poisonArrow;

    public SkillsData(bool fireArrow, bool frozenArrow, bool poisonArrow)
    {
        this.fireArrow = fireArrow;
        this.frozenArrow = frozenArrow;
        this.poisonArrow = poisonArrow;
    }
}

[Serializable]
public struct UserData
{
    public string position;
    public string userName;
    public int coins;
    public int ingots;
    public int level;
    public SkillsData skillsData;
    public string created;
    public string updated;
    public string lastLogged;

    public UserData(string position, string userName, int coins, int ingots, int level, SkillsData skillsData, string created, string updated, string lastLogged)
    {
        this.position = position;
        this.userName = userName;
        this.coins = coins;
        this.ingots = ingots;
        this.level = level;
        this.skillsData = skillsData;
        this.created = created;
        this.updated = updated;
        this.lastLogged = lastLogged;
    }
}

[Serializable]
public struct RankingData
{
    public int numberPlayers;
    public UserData[] users;

    public RankingData(int numberPlayers, UserData[] users)
    {
        this.numberPlayers = numberPlayers;
        this.users = users;
    }
}

[Serializable]
public struct ServerCode
{
    public int code;
    public bool error;
    public string message;
    public UserData User;

    public ServerCode(int code, bool error, string message, UserData User)
    {
        this.code = code;
        this.error = error;
        this.message = message;
        this.User = User;
    }
    
    public ServerCode(int code, bool error, string message)
    {
        this.code = code;
        this.error = error;
        this.message = message;
        this.User = new UserData();
    }
}