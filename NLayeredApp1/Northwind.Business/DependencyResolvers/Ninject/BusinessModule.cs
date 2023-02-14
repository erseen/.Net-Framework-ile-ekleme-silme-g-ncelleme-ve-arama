using Ninject.Modules;
using Norhwind.DataAccess.Abstract;
using Norhwind.DataAccess.Concrete.Entity_Framework;
using Norhwind.DataAccess.Concrete.EntityFramework;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
   public   class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

        }

    }
}
