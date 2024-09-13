﻿namespace DotNetHW2;

public class User
{
    private string username { get; set; }
    private string password { get; set; }
    private Item[] shoppingList { get; }

    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
        this.shoppingList = new Item[5];
    }
}