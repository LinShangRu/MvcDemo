using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcDemo.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        internal 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(m => m.Id == id);
        }

        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(o => false == o.是否已刪除);
            //return base.All();
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
            //base.Delete(entity);
        }
    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}