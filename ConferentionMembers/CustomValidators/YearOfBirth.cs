using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConferentionMembers.CustomValidators
{
    public class YearOfBirth : RangeAttribute
    {
        public YearOfBirth() :base (DateTime.Now.AddYears(-150).Year,DateTime.Now.Year)
        { }
    }
}