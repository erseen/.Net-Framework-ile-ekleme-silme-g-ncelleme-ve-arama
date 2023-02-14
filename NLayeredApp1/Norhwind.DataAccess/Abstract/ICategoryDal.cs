using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norhwind.DataAccess.Abstract
{
  public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
