using static DemoUI.ListGenerator;

using DemoUI;
using System.Collections.Generic;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Restruction [Where]

            #endregion

            #region Ordering 

            //Order By
            var result = ProductsList.OrderBy(P=> P.UnitsInStock); //Asc

            var resultDesc = ProductsList.OrderByDescending(P=> P.UnitsInStock); //Asc

            resultDesc = from P in ProductsList
                         orderby P.UnitsInStock descending
                         select P;
            //Helper.PrintToScreen(result);


            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }



            #endregion

            #region Transformation Operator [Projection]
            //Select / Select Many

            //Select -> if we need to select one value 
            //Select Many -> if we need to select many values


            Console.WriteLine("===");

            //var trans = ProductsList.Select(P => P.ProductName);

            //var trans = ProductsList.Where(P => P.UnitsInStock == 0).Select(P => $"{P.ProductName} - {P.ProductID}");


            //var trans = from p in ProductsList
            //            where p.UnitsInStock == 0
            //            select $"{p.ProductName} :: {p.ProductID}";


            //var trans = CustomersList.SelectMany(P => P.Orders);


            //var trans = from o in CustomersList
            //            from c in o.Orders
            //            select c;


            var trans = ProductsList.Where(P => P.UnitsInStock == 0).Select(P =>  new{ P.ProductID , P.ProductName , Status = "Stock Less Than 0" });


            Helper.PrintToScreen(trans);

            #endregion

            #region Element Operator [Immediate]

            //Retreieve spacific elements from collection based on certain conditions

            //First => Returns the first element of a sequence.
            // will throw an exception if the sequence has no element
            //var element = ProductsList.First().ProductName;

            //int[] numbers = new int[] { };
            //var element = numbers.First(); //Exception because array has no element
            //Console.WriteLine(element);



            //int[] numbers = new int[] { };
            //var element = numbers.FirstOrDefault(); 
            //Console.WriteLine(element);

            //int[] numbers = new int[] { 1, 2, 3 };
            //var element = numbers.First(); 
            //Console.WriteLine(element);


            //Last
            //Returns the last element of a sequence.
            //int[] numbers = new int[] { };
            //var last = numbers.Last(); // will throw an exception 

            //int[] numbers = new int[] { };
            //var last = numbers.LastOrDefault(); 

            //int[] numbers = new int[] { };
            //var last = numbers.LastOrDefault(100);

            //Console.WriteLine(last);





            #endregion

            #region AggregateOperator [Immediate]

            //Count - Sum - Avg - Min - Max

            var elementCount = ProductsList.Count(P => P.UnitsInStock == 0);
            // ProductsList.Count;


            //var res = ProductsList.Sum(P => P.UnitsInStock);


            Console.WriteLine("==========");
            var res = ProductsList.Max();

            Console.WriteLine(res);


            //MaxBy => will retuurn the owner of the condition

            #endregion

            #region Set Operator [Union Family]
            var seq01 = Enumerable.Range(0, 100);
            var seq02 = Enumerable.Range(50, 149);

            //var resultt = seq01.Union(seq02); //Without Duplication

            //With Duplication 

            //var resultt = seq01.Concat(seq02); //Without Dupli


            //var resultt = seq01.Intersect(seq02); //Common

            var resultt = seq01.Intersect(seq02); //Except
            Helper.PrintToScreen(resultt);
            #endregion

            #region Quantifier operators [Return Bool]
            //Any - All - SequenceEqual - Contains

            //Any -> true -> if there is at least one Element [In the sequence or match the condition] 

            //Console.WriteLine(ProductsList.Any());

            var r = ProductsList.Any(P => P.UnitPrice == 0); // true


            //All() -> True -> if All element math the condition or sequence is empty

            ProductsList.All(P => P.UnitsInStock == 0); // false

            ProductsList.All(P => P.UnitPrice > 0); // true


            //SequenceEqual -> total item in the first seq equal the total in the second 



            //Contains > 
            //ProductsList.Contains();





            #endregion

            #region Zipping Operator
            //Zip 
            List<string> words = new List<string>() { "Ten","Hi","Hello"};

            List<int> numbers = new List<int>() { 10, 20, 30};

            words.Zip(numbers, (W, N) => $"{W} {N}");

            #endregion

            #region Groupping
            Console.WriteLine("---------------------------------------");
            var x = ProductsList.GroupBy(P => P.Category);
            foreach(var cat in x) 
            {
                Console.WriteLine(cat.Key);
                foreach(var item in cat) 
                {
                    Console.WriteLine(item);
                }
            }
            #endregion
        }
    }
}
