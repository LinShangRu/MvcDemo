using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcDemo.Models.Validations
{
    public class 手機格式必須正確Attribute: DataTypeAttribute
    {
        public 手機格式必須正確Attribute() : base(DataType.Text)
        {
            this.ErrorMessage = this.GetType().Name.Replace("Attribute","");
        }

        public override bool IsValid(object value)
        {
            string MyPattern = @"\d{4}-\d{6}";
            Regex MyRegex = new Regex(MyPattern, RegexOptions.IgnoreCase);
            if (MyRegex.IsMatch(Convert.ToString(value)))
                return true;
            else
                return false;
        }
    }
}