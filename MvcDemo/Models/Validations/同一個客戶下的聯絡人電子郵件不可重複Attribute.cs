using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models.Validations
{
    public class 同一個客戶下的聯絡人電子郵件不可重複Attribute : DataTypeAttribute
    {
        string MyEmail { get; set; }
        int 客戶ID { get; set; }

        public 同一個客戶下的聯絡人電子郵件不可重複Attribute(int 客戶ID,string MyEmail) : base(DataType.Text)
        {
            this.ErrorMessage = this.GetType().Name.Replace("Attribute", "");
            this.MyEmail = MyEmail;
            this.客戶ID = 客戶ID;
        }

        public override bool IsValid(object value)
        {
            客戶聯絡人Repository db = RepositoryHelper.Get客戶聯絡人Repository();
            if (db.檢查同一個客戶下的聯絡人電子郵件不可重複(this.客戶ID, this.MyEmail))
            {
                return true;
            }
            else
                return false;
        }
    }
}