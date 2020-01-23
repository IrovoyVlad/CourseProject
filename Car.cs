using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Car:IWritebleObject
    {
        private string numbercar;//Номерной знак автомобиля
        private string carbrand;//Марка автомобиля
        private string carmoadel;//Модель автомобиля
        private double run;//Пробег
        private double carrying;//Грузоподъемность
        private double consumption;//Расход топлива на 100 км.
        private Category category;
        //
        //Конструктор с параметрами, который инициализирует поля класса
        //
        public Car(string numbercar,string carbrand,string carmodel,double run, double carrying,double consumption,Category category)
        {
            this.numbercar = numbercar;
            this.carbrand = carbrand;
            this.carmoadel = carmodel;
            this.run = run;
            this.carrying = carrying;
            this.consumption = consumption;
            this.category = category;
        }
        //
        //Конструктор без параметров который считывает поля класса
        //
        public Car()
        {
            Console.WriteLine("Введите номерной знак автомобиля: ");
            numbercar = Console.ReadLine();
            Console.WriteLine("Введите марка автомобиля автомобиля: ");
            carbrand= Console.ReadLine();
            Console.WriteLine("Введите модель автомобиля автомобиля: ");
            carmoadel = Console.ReadLine();
            Console.WriteLine("Введите категорию автомобиля: ");
            
            do
            {
                Console.WriteLine("Введите пробег автомобиля(км): ");
                run = double.Parse(Console.ReadLine());
            } while (run < 0);
            do
            {
                Console.WriteLine("Введите грузоподъемность автомобиля(кг): ");
                carrying = double.Parse(Console.ReadLine());
            } while (carrying < 0);
            category = new Category(Category.isCategory(carrying));
            do
            {
                Console.WriteLine("Введите расход топлива на 100 км автомобиля: ");
                 consumption= double.Parse(Console.ReadLine());
            } while (consumption < 0);

        }
        
        public string getNumbercar()
        {
            return numbercar;
        }
        /*public void addRun(double run)
        {
            this.run += run;
        }*/
     
        public char getCategory()
        {
            return category.value;
        }
        public void Write(SaveManager sw)
        {
            sw.WriteLine($"номерной знак автомобиля: {numbercar} ");         
            sw.WriteLine($"марка автомобиля автомобиля: {carbrand} ");          
            sw.WriteLine($"модель автомобиля автомобиля: {carmoadel} ");  
            sw.WriteLine($" пробег автомобиля(км): {run}");
            sw.WriteLine($" грузоподъемность автомобиля(кг): {carrying}");
            sw.WriteLine($" расход топлива на 100 км автомобиля: {consumption} ");
            sw.WriteLine($" категория автомобиля:  {getCategory()}");
        }
        
    }
}
