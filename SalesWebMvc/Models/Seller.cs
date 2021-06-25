using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name="NOME")]
        public string Name { get; set; }
        [Display(Name = "E-MAIL")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "DATA DE NASCIMENTO")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "SALÁRIO BASE")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; } 
        public Departament Departament{ get; set; }
        public int DepartamentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Departament = departament;
        }

        public void AdicionarSale(SalesRecord sr)
        {
            SalesRecords.Add(sr);
        }
        public void RemoverSale(SalesRecord sr)
        {
            SalesRecords.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
