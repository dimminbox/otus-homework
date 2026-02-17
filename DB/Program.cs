namespace Db;

class Program
{
    public const string ConnectionString = "Host=localhost;Username=postgres;Password=postgres;Database=otus";

    static void Main(string[] args)
    {
        foreach (var arg in args)
        {
            switch (arg)
            {
                case "--createStructure":
                    DbStructureCreator.CreateProductTable();
                    DbStructureCreator.CreateUserTable();
                    DbStructureCreator.CreateOrdersTable();
                    DbStructureCreator.CreateOrderDetailsTable();
                    break;
                case "--insertProduct":
                    ProductManipulator.Insert1();
                    ProductManipulator.Insert0();
                    break;
                case "--updatePrice":
                    ProductManipulator.Update(1);
                    break;
                case "--getStock":
                    ProductManipulator.GetStock();
                    break;
                case "--getMostExpansiveProducts":
                    ProductManipulator.GetTop5MostExpansiveProducts();
                    break;
                case "--getScarceItems":
                    ProductManipulator.GetScarceItems();
                    break;
                case "--insertUser":
                    UserManipulator.Insert();
                    break;
                case "--insertOrder":
                    OrderManipulator.Insert();
                    break;
                case "--getByUser":
                    OrderManipulator.GetByUser(1);
                    break;
                case "--getTotalPrice":
                    OrderManipulator.getTotalPrice(16);
                    break;
            }
        }
    }
}