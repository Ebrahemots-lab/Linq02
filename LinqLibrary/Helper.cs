using System.Collections;

namespace DemoUI
{
    public static class Helper
    {
        public static void PrintToScreen(IEnumerable list) 
        {
            foreach(var item in list) 
            {
                Console.WriteLine(item);
            }
        }
    }
} 
