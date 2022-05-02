using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Project
{
    public class Checkout
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string DogId { get; set; }
        public string Address { get; set; }
       
    }
}
