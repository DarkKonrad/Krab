using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz_Prot.Models
{
    class Employee
    {
        string name, surname, pesel,address;
        DateTime birthDay, hireFrom;
        DateTime? expDate;
        User.Privileges privileges;
        

        #region Getters and Setters
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string Address { get => address; set => address = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime HireFrom { get => hireFrom; set => hireFrom = value; }
        public DateTime? HireExp { get => expDate; set => expDate = value; }
        public User.Privileges Privileges { get => privileges; set => privileges = value; }

        #endregion
        public Employee(string name, string surname, string pesel, string address, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.address = address;
            this.birthDay = birthDay;
            this.hireFrom = hireFrom;
            this.expDate = expDate;
        }
        public int Age()
        {

            var age = DateTime.Now - BirthDay.Date;
            return int.Parse(( age.Days / 365 ).ToString());
            
        }
        public void AddEmployee(string name, string surname, string pesel, string address, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            string command = "INSERT INTO employees VALUES (@name,@surname,@pesel,@address,@birthDay,@hireDate,@expDate)";
            var query = new MySql.Data.MySqlClient.MySqlCommand(command, dbTools.dbAgent.GetConnection());

            query.Parameters.AddWithValue("@name", name);
            query.Parameters.AddWithValue("@surname", surname);
            query.Parameters.AddWithValue("@pesel", pesel);
            query.Parameters.AddWithValue("@address", address);
            query.Parameters.AddWithValue("@birthday",birthDay.Date.ToString("DD-MM-YYYY"));
            query.Parameters.AddWithValue("@hireDate", hireFrom.Date.ToString("DD-MM-YYYY"));
            if(!expDate.HasValue)
            {
                query.Parameters.AddWithValue("@hireExp",null);
            }
            query.Parameters.AddWithValue("@expDate", expDate.Value.Date.ToString("DD-MM-YYYY"));


        }

      



    }
}
