using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rabbit
{
    public class NEDOController
    {
        public List<Product> FindAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                
                return db.product.ToList();
            }
        }
        public List<Product> FindbyID(int id)
        {
            
            Product product = new Product();
            using (ApplicationDbContext db = new ApplicationDbContext())
                 product = db.product.ToList().FirstOrDefault(x => x.ID == id);

            List<Product> listProduct = new List<Product>() { product};
            return listProduct;
            //listProduct.Add(product);

            //Console.WriteLine(product2.ID);
           
            
        }
        public List<Product> Create( Product product)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //вытаскиваю имя , проверяю нал или нет, и если нал выводить об ошибке.
                //Product product1 = new Product { Name = name, Price = price };
                db.product.Add(product);
                db.SaveChanges();
                List<Product> listProduct = new List<Product>() { product };
                Console.WriteLine(product.ID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                return listProduct;
            }

        }
        public List<Product> Update(int id, Product product)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var product1 = db.product.FirstOrDefault(x => x.ID == id);
                product1.Name = product.Name;
                product1.Price = product.Price;
                db.SaveChanges();
                List<Product> listProduct = new List<Product>() { product };
                return listProduct;
            }
        }
        
        public List<Product> Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var product = db.product.Where(o => o.ID == id).FirstOrDefault();
                db.product.Remove(product);
                db.SaveChanges();
                List<Product> listProduct = new List<Product>() { product };
                return listProduct;
            }
        }
    }
}
