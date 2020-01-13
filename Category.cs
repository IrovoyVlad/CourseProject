using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Category
    {
        public char value;
        //
        //Конструктор без параметров, который считывает поле класса
        //
        public Category()
        {
            value = char.Parse(Console.ReadLine());
        }

        //
        //Конструктор с параметрам, который инициализирует поле класса
        //
        public Category(char c)
        {
            value = c;
        }
        //
        //
        //
        public static char isCategory(double wheigth)
        {
            
            if (wheigth > 1 && wheigth < 100)
            {
                return 'A';
            }
            if(wheigth > 100 && wheigth < 1000){
                return 'B';
            }
            if (wheigth > 1000 && wheigth < 10000)
            {
                return 'C';
            }
           
                return 'D';
            
        }

    }
}
