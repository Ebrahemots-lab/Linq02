using DemoUI;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading;
using System.Xml;
using static DemoUI.ListGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Restriction Operators

            //Find all products that are out of stock.
            var outOfStockProducts = ProductsList.Where(P => P.UnitsInStock == 0);

            //Helper.PrintToScreen(outOfStockProducts);


            //Find all products that are in stock and cost more than 3.00 per unit
            var productsCostMoreThan3 = ProductsList.Where(P => P.UnitPrice > 3);

            //Helper.PrintToScreen(productsCostMoreThan3);



            //Returns digits whose name is shorter than their value.
           string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitShorterThanTheirValue = Arr.Where((P, I) =>
            {
                return I > P.Length;
            });

            //Helper.PrintToScreen(digitShorterThanTheirValue);


            #endregion

            #region Ordering 

            //Sort a list of products by name
            var sortedByName = ProductsList.OrderBy(P => P.ProductName);

            //Helper.PrintToScreen(sortedByName);


            string[] Arr01 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedResult = Arr01.OrderBy(P => P,StringComparer.OrdinalIgnoreCase); // => Searched From Internet

            //Helper.PrintToScreen(sortedResult);

            //Sort a list of products by units in stock from highest to lowest.
            var sortedByStockHToLow = ProductsList.OrderByDescending(P => P.UnitsInStock);

            //Helper.PrintToScreen(sortedByStockHToLow);

            //Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            string[] Arr02 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigitByLengthThenAlphabet = Arr02.OrderBy(P => P.Length).ThenBy(digit => digit);

            //Helper.PrintToScreen(sortedDigitByLengthThenAlphabet);

            //5.Sort first by word length and then by a case -insensitive sort of the words in an array.

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedByWordLengthThenCaseSensetive = words.OrderBy(P => P.Length).ThenBy(P => P ,StringComparer.OrdinalIgnoreCase); // => Searched From Internet

            //Helper.PrintToScreen(sortedByWordLengthThenCaseSensetive);


            // 6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
            var sortedProductsByCategoryThenUnitPriceDesc = ProductsList.OrderByDescending(P => P.Category).ThenBy(P => P.UnitPrice);

            //Helper.PrintToScreen(sortedProductsByCategoryThenUnitPriceDesc);


            //7.Sort first by word length and then by a case -insensitive descending sort of the words in an array.
            string[] Arr03 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedByWordLengthThenCaseInsensitive = Arr03.OrderByDescending(W => W.Length).ThenBy(W => W , StringComparer.OrdinalIgnoreCase);

            //Helper.PrintToScreen(sortedByWordLengthThenCaseInsensitive);


            //8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr04 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var digitsWithSecondLetterI = Arr04.Where(P => P[1] == 'i').Reverse();

            Helper.PrintToScreen(digitsWithSecondLetterI);

            #endregion

            #region Element Operator
            //1.Get first Product out of Stock

            var firstOutOfStock = ProductsList.Where(P => P.UnitsInStock == 0).First();
            Console.WriteLine(firstOutOfStock);

            //2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned
            var firstProductWithPriceLargeThan1000 = ProductsList.Where(P => P.UnitPrice > 1000).FirstOrDefault();
            Console.WriteLine(firstProductWithPriceLargeThan1000);


            //3.Retrieve the second number greater than 5
            int[] Arr05 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNumbersLargerThan5 = Arr05.Where(N => N > 5).OrderBy(N => N).ElementAt(1);
            Console.WriteLine(secondNumbersLargerThan5);






            #endregion

            #region Aggregate Operator
            //1.Uses Count to get the number of odd numbers in the array
            int[] Arr06 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var countOfOddNumbers = Arr06.Where(N => N % 2 != 0).Count();
            //Console.WriteLine(countOfOddNumbers);

            //2.Return a list of customers and how many orders each has.
            var customers = CustomersList.Select(C => new { C.CustomerName ,  C.CustomerID , OrderCount = C.Orders.Count()});
            //Helper.PrintToScreen(customers);

            
            //3.Return a list of categories and how many products each has
            var cat = ProductsList.Select(P => new { P.Category , CountOfProducts = P.Category.Count()}); //Not Solved
            //Helper.PrintToScreen(cat);


            //Get the total of the numbers in an array.
            int[] Arr07 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var totalSum = Arr07.Sum();
            Console.WriteLine(totalSum);


            //5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var f = File.ReadLines("dictionary_english.txt");
            var totaalNumberOfChars = f.Select(T => new { Name = T, Length = T.Length}); //Length
            var totalSumx = f.Sum(x => x.Length);
            //Console.WriteLine(totalSumx);

            //6.Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var shortWordLength = f.Select(T => T.Length).Min();
            Console.WriteLine(shortWordLength);

            //7.Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var longestWordLength = f.Select(T => T.Length).Max();
            Console.WriteLine(longestWordLength);


            //.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var Avg = f.Select(T => T.Length).Average();
            Console.WriteLine(Avg);

            //9.Get the total units in stock for each product category.
            var category = ProductsList.Select(C => new
            {
                C.Category,
                Units = ProductsList.Where(c => c.UnitsInStock == C.UnitsInStock), 
                
            });

            Helper.PrintToScreen(category);

            //10.Get the cheapest price among each category's products
            Console.WriteLine("--------------------");
            var CheapestPrice = ProductsList.GroupBy(P => P.Category).Select(C => C.Min(X => X.UnitPrice)).First();
            Console.WriteLine(CheapestPrice);



            #endregion

            #region Set Operator
            //1.Find the unique Category names from Product List
            var uniqueCategoryNames = ProductsList.Select(P => P.Category).Distinct();
            //2.Produce a Sequence containing the unique first letter from both product and customer names.

            // var res = ProductsList.Select(P => P.ProductName[0]).Union(CustomersList.Select()); Not Solved Yet



            //3.Create one sequence that contains the common first letter from both product and customer names.
            var res = ProductsList.Select(P => P.ProductName[0]).Intersect(CustomersList.Select(C => C.CustomerName[0]));


            //4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var restt = ProductsList.Select(P => P.ProductName[0]).Except(CustomersList.Select(C => C.CustomerName[0]));


            //5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
            //Not Solved yET



            #endregion

            #region Quantifiers
            //1.Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            bool isContain = f.Any(c => c.Contains("ei"));
            Console.WriteLine(isContain);

            //2.Return a grouped a list of products only for categories that have at least one product that is out of stock.
            //var grouppedByCategory = ProductsList.GroupBy(P => P.Category);
            //var atLeastOneProduct = grouppedByCategory.Where(C => C.Any(Pro => Pro.UnitsInStock == 0));

            //3.Return a grouped a list of products only for categories that have all of their products in stock.

            var grouppedByCategory = ProductsList.GroupBy(P => P.Category);
            var atLeastOneProduct = grouppedByCategory.Where(C => C.All(Pro => Pro.UnitsInStock == 0));

            #endregion

        }
    }
}
