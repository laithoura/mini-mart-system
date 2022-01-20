using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mart.InstanceClasses;
namespace Mart.InstanceClasses
{
    public delegate void CreatedHanding(Supplier sup);
    public delegate void UpdatedHanding(Supplier sup);
    public delegate void LoadedHanding(Supplier sup);
    public class Supplier
    {
        public static event CreatedHanding Created = null;
        public static event UpdatedHanding Updated = null;
        public static event LoadedHanding Loaded = null;
       
       
          


        public static void CreatedInstance(int supID, string firstName, string lastName, string gender, DateTime birthdate, string PNumber, string email, string company)
        {
            Supplier sup = new Supplier(supID, firstName, lastName, gender, birthdate, PNumber, email, company);
            if (Created != null) Created(sup);
        }


        public int RowCount { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string pNumber { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public object Tag { get; set; }
        public Supplier(int id, string firstName, string lastName, string gender, DateTime birthdate, string PNumber, string email, string company)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.pNumber = PNumber;
            this.Email = email;
            this.Company = company;
        }



    
       public static void LoadedInstance(int SupId, string firstName, string lastName, string gender, DateTime birthDate, string PNumber, string email, string company)
        {
            Supplier sup = new Supplier(SupId, firstName, lastName, gender, birthDate, PNumber, email, company);
            if (Loaded != null) Loaded(sup);
        }
       


       public void setSupplierData(int SupId, string firstName, string lastName, string gender, DateTime birthDate, string PNumber, string email, string company)
       {
           this.ID = SupId;
           this.FirstName = firstName;
           this.LastName = lastName;
           this.Gender = gender;
           this.BirthDate = birthDate;
           this.pNumber = PNumber;
           this.Email = email;
           this.Company = company;

           if (Updated != null)
           {
               //Supplier sup = new Supplier(SupId, firstName, lastName, gender, birthDate, PNumber, email, company);
               Updated(this);

           }
       }
}




}
