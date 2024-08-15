namespace DemoUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Filteration [Where]

            #endregion
            var outOfStock = ListGenerator.ProductsList.Where(P => P.UnitsInStock == 0);



            var outOfStockQuery = from P in ListGenerator.ProductsList
                                  where P.UnitsInStock == 0
                                  select P;


            //also we can use and Operator to validate the output more 


            outOfStock = ListGenerator.ProductsList.Where(P => P.UnitsInStock == 0 && P.Category == "Condiments");


            //Second version of Where [Indexed Where]
            outOfStock = ListGenerator.ProductsList.Where((P,I) => P.UnitsInStock == 0 && I <= 10);


            outOfStock = ListGenerator.ProductsList.OfType<Product02>().Where(P => P.ProductID == 11);


            Helper.PrintToScreen(outOfStock);
        }
    }
}
