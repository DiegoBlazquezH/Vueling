using Redis.Common.Models;
using RedisBusiness;
using System;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentBL studentBL = new StudentBL();
            Student student1= new Student(1, "Diego", "Blázquez");
            Student student2 = new Student(2, "Juan", "Pérez");

            studentBL.Save("prueba1", student1);
            Student temp = studentBL.Read("prueba1");
            Console.WriteLine(temp.ToString());

            studentBL.Save("prueba2", student2);
            temp = studentBL.Read("prueba2");
            Console.WriteLine(temp.ToString());

            Console.ReadLine();
        }
    }
}