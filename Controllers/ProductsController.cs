//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Rabbit.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class HightController : Controller
//    {


//        // GET: api/<SwitchController>
//        [HttpGet]
//        public List<Product> FindAll()
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//                return db.product.ToList();
//        }

//        // GET api/<MainController>/5
//        [HttpGet("{id}")]
//        public Product FindbyID(int id)
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//                return db.product.FirstOrDefault(x => x.ID == id);
//        }

//        // POST api/<MainController>
//        [HttpPost]
//        public Product Create([FromBody] Product product)
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//            {
//                //вытаскиваю имя , проверяю нал или нет, и если нал выводить об ошибке.
//                //Product product1 = new Product { Name = name, Price = price };
//                db.product.Add(product);
//                db.SaveChanges();
//                return product;
//            }

//        }

//        // PUT api/<MainController>/5
//        [HttpPut("{id}")]
//        public Product Update(int id, [FromBody] Product product)
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//            {
//                var product1 = db.product.FirstOrDefault(x => x.ID == id);
//                product1.Name = product.Name;
//                product1.Price = product.Price;
//                db.SaveChanges();
//                return product1;
//            }
//        }

//        // DELETE api/<MainController>/5
//        [HttpDelete("{id}")]
//        public Product Delete(int id)
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//            {
//                var product = db.product.Where(o => o.ID == id).FirstOrDefault();
//                db.product.Remove(product);
//                db.SaveChanges();
//                return product;
//            }
//        }
//    }
//}
