﻿namespace APIshka.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<New> New {  get; set; }
    }
}
