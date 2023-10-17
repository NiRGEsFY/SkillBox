using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Первое задание
            string firstName = "Nick";
            string lastName = "Rad";
            string surName = "Alex";
            double markOfProgramming = 6.1;
            double markOfMatematic = 7.8;
            double markOfPhysic = 8.9;
            uint age = 22;
            string email = "email@mail.ru";
            Console.WriteLine($"FirstName: {firstName}\n" +
                              $"LastName: {lastName}\n" +
                              $"SurName: {surName}\n" +
                              $"Age: {age}" +
                              $"Email: {email}" +
                              $"Mark of Programming: {markOfProgramming}\n" +
                              $"Mark of Matematic: {markOfMatematic}\n" +
                              $"Mark of Physic: {markOfPhysic}\n");

            //Второе задание
            double sumOfAllSubjects;
            sumOfAllSubjects = markOfProgramming + markOfMatematic + markOfPhysic;
            double averageOfAllSubjects;
            averageOfAllSubjects = sumOfAllSubjects / 3;
            Console.WriteLine($"Sum of all marks: {sumOfAllSubjects}\n" +
                              $"Average of all marks: {averageOfAllSubjects}");
        }
    }
}
