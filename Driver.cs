using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Driver
    {
        private int persnumber;//Табельный номер водителя
        private string FIO;//ФИО водителя
        private DateTime datebirth;//Дата рождения
        private double experience;//Стаж работы
        private Category category;//Категория
        private double salary;//Оклад 
        //
        //Конструктор с параметрами, который инициализирует поля класса
        //
        public Driver(int persnumber, string FIO, DateTime datebirth, double experience,Category category,double salary)
        {
            this.persnumber = persnumber;
            this.FIO = FIO;
            this.datebirth = datebirth;
            this.experience = experience;
            this.category = category;
            this.salary = salary;
        }
        //
        //Конструктор без параметров который считывает поля класса
        //
        public Driver()
        {
            Console.WriteLine("Введите пресональный номер водителя: ");
            persnumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ФИО водителя: ");
            FIO = Console.ReadLine();
            int year, day, month;
            do
            {
                Console.WriteLine("Введите день,месяц и год рождения водителя(через Enter): ");
                day = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                year = int.Parse(Console.ReadLine());
            } while (day <= 0 || day > 31 || month <= 0 || month > 12 || year < 1900 || year > 2002);
            datebirth = new DateTime(year, month, day);
            do
            {
                Console.WriteLine("Введите стаж водителя: ");
                experience = double.Parse(Console.ReadLine());
            } while (experience<0);
           
            Console.WriteLine("Введите категорию водителя: ");
            category = new Category();
            do
            {
                Console.WriteLine("Введите оклад водителя: ");
                salary = double.Parse(Console.ReadLine());
            }while(salary < 0);

        }
        public void setCategory(Category newcategory)
        {
            category = newcategory;
        }
        public int getPersnumber()
        {
            return persnumber;
        }
        public char getCategory()
        {
            return category.value;
        }
       /* public void setSalary(double newsalary)
        {
            salary = newsalary;
        }
        public void addExperience(double exp)
        {
            experience += exp;
        }*/
     
        public double getSalary()
        {
            return salary;
        }
        public void Print(StreamWriter sw)
        {
            sw.WriteLine($"пресональный номер водителя: {persnumber} ");
            sw.WriteLine($" ФИО водителя: {FIO}");
            sw.WriteLine($"день,месяц и год рождения водителя(через Enter): {datebirth.ToString()}");
            sw.WriteLine($"стаж водителя: {experience}");
            sw.WriteLine($"категорию водителя: {getCategory()}");           
            sw.WriteLine($"оклад водителя: {salary}");
               
        }
        
    }
}
 