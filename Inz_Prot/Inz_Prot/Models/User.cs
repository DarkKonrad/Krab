using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Inz_Prot.Models
{
    public class User
    {
        public enum Privileges
        {
            Zwykły = 1,
            Admin = 2,
            Uprzywilejowany = 3,
            //HR = 4,
            //Salesman =5,


        }
        string name, surname, login;
        int  Id;
        Privileges privilege;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Login { get => login; set => login = value; }
        public int ID { get => Id; set => Id = value; }
        public Privileges Privilege { get => privilege; set => privilege = value; }

        public User(int ID,string name, string surname, Privileges privileges)
        {
            this.name = name;
            this.surname = surname;
            this.privilege = privileges;
            this.Id = ID;
        }

        public User(int id, string name, string surname, string login,  Privileges privilege)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            Id = id;
            this.privilege = privilege;
        }
    }
}
