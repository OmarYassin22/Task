using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Applicant : BaseModel
    {

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        [EmailAddress]
        public string EmailAdress { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        public bool Hired { get; set; } = false;


    }
}
