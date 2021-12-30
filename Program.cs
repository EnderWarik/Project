using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client.Events;
using Newtonsoft.Json.Linq;
    
namespace Rabbit;
class Program
{
    static void Main(string[] args)

    {
        NEDOController controller = new NEDOController();
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingkey = e.RoutingKey;
                JObject json_object = JObject.Parse(message);
                 //Console.WriteLine("{1}.{0}", json_object, routingkey);
                var Method = JsonConvert.SerializeObject(json_object["Method"]);


                Console.WriteLine(Method);
                if (Method == "\"GET\"")
                {
                    List<Product> list = controller.FindAll();
                    
                    CreateTuck(list);

                }
                if (Method == "GETBYID")
                {
                    var id = Convert.ToInt32(JsonConvert.SerializeObject(json_object["Body"]["ID"]));
                    List<Product> list = controller.FindbyID(id);
                    CreateTuck(list);//gogo

                }
                if (Method == "POST")
                {
                    var price = Convert.ToInt32(JsonConvert.SerializeObject(json_object["Body"]["Price"]));
                    var name = JsonConvert.SerializeObject(json_object["Body"]["Name"]);
                    List<Product> list = controller.Create(new Product {Name = name,Price= price });
                    CreateTuck(list);

                }
                if (Method == "PUT")
                {
                    var id = Convert.ToInt32(JsonConvert.SerializeObject(json_object["Body"]["ID"]));
                    var price = Convert.ToInt32(JsonConvert.SerializeObject(json_object["Body"]["Price"]));
                    var name = JsonConvert.SerializeObject(json_object["Body"]["Name"]);
                    List<Product> list = controller.Update(id,new Product { Name = name, Price = price });
                    CreateTuck(list);

                }
                if (Method == "POST")
                {
                    var id = Convert.ToInt32(JsonConvert.SerializeObject(json_object["Body"]["ID"]));
                    List<Product> list = controller.Delete(id);
                    CreateTuck(list);

                }



            };
            channel.BasicConsume(queue: "Request",
                                 autoAck: true,
                                 consumer: consumer);
            Console.ReadKey();
        }
    }


        static void CreateTuck(List<Product> list)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Response", //cоздает очередь
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


            // var products = @(Html.Raw(Json.Encode(products)));

            //string message = JsonConvert.SerializeObject(list);


            //Product data2 = JsonConvert.DeserializeObject<Product>(message);
            //string m = JsonConvert.SerializeObject(list);
            //var test = JsonConvert.DeserializeObject(m);
            string message = JsonConvert.SerializeObject(list);
            //var json_object = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(message);
            //string messageq = JsonConvert.SerializeObject(json_object);

            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",               //отправляет сообщение в очередь
                                     routingKey: "Response",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($"                                                                             Message {message} Publish to Response ");

            }
           

        }
        
    
}