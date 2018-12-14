using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Inz_Prot.Models
{
   public class Employee
    {
        int? id;
        string name, surname, pesel,address,position;
        DateTime birthDay, hireFrom;
        DateTime? expDate;
       
        

        #region Getters and Setters
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string Address { get => address; set => address = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public DateTime HireFrom { get => hireFrom; set => hireFrom = value; }
        public DateTime? HireExp { get => expDate; set => expDate = value; }
        public string Position { get => position; set => position = value; }
        public int? ID { get => id; set => id = value; }


        #endregion
        public Employee(int? id,string name, string surname, string pesel, string address, string position, DateTime birthDay, DateTime hireFrom, DateTime? expDate)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.address = address;
            this.birthDay = birthDay;
            this.hireFrom = hireFrom;
            this.expDate = expDate;
            this.position = position;
            // Warning
            this.ID = id;
        }
        public int Age()
        {

            var age = DateTime.Now - BirthDay.Date;
            return int.Parse(( age.Days / 365 ).ToString());
            
        }
        
      
    
    }
}
