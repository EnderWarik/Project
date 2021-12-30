namespace Rabbit
{
    public class Product
    {
        public Product() { }
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }

        //create read(FindbyId(where id) fiandAll(****) update(insert id name price into products) delete
        //public override string ToString()
        //{
        //    return "{\n" + "\"ID\": \"" + ID + "\"\n" + "\"Name\": \"" + Name + "\"\n" + "\"Price\": \"" + Price + "\"\n }"; // типо JSON формат
        //}
    }
}
