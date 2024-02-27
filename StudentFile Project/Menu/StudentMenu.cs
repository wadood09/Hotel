using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Entities;
using StudentFile_Project.Services.Implementations;
using StudentFile_Project.Services.Interfaces;

namespace StudentFile_Project.Menu
{
    public class StudentMenu
    {
        IExamServices _examServ = new ExamServices();
        Exam exam = new Exam();

        public void MenuStudent()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Student's Menu");
                Console.WriteLine("1:Participate in exam");
                Console.WriteLine("2:Check Grade");
                Console.WriteLine("3:View Score Ranks");
                Console.WriteLine("0:Exit");
                string userInput = Console.ReadLine()!;
                switch (userInput)
                {
                    case "1":
                        Exam();
                        break;
                }
            }
        }
        private void Exam()
        {
            if(_examServ.IsExamDone() == false)
            {
            Console.WriteLine("Exam");
            Console.WriteLine("NOTE: FILL IN THE CORRECT ANSWERS");
            Console.WriteLine("Chemistry");
            Console.WriteLine();
            Console.WriteLine("Question 1:Chemistry is The study of ______?");
            Console.WriteLine("Options   A:Animal B:Matter C:Plant");
            string chemOneAns = Console.ReadLine()!;
            if (chemOneAns.ToUpper() == "B")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("Question 2:_____is the smallest recognized chemical element");
            Console.WriteLine("Options   A:Atom B:Dust C:Seed");
            string chemTwoAns = Console.ReadLine()!;
            if (chemTwoAns.ToUpper() == "A")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("Question 3:The S I unit of temperature is________?");
            Console.WriteLine("Options   A:Seconds B:Kelvin C:Length");
            string chemThreeAns = Console.ReadLine()!;
            if (chemThreeAns.ToUpper() == "B")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("Question 4:Amino Acids are obtained from proteins by_______?");
            Console.WriteLine("Options   A:Hydrolysis B:Crystallization C:Beans");
            string chemFourAns = Console.ReadLine()!;
            if (chemFourAns.ToUpper() == "A")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("Question 5: Ripening of fruit is hastened by ______?");
            Console.WriteLine("Options   A:Photosynthesis B:Ethyne C:Ethene");
            string chemFiveAns = Console.ReadLine()!;
            if (chemFiveAns.ToUpper() == "C")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("Question 1:Biology is the Scientific Study of?");
            Console.WriteLine("Options   A:Animal B:Life C:Plant");
            string bioOneChoice = Console.ReadLine()!;
            if (bioOneChoice.ToUpper() == "B")
            {
                exam.Score++;
            }
            Console.WriteLine();

            Console.WriteLine("Question 2:Biology can aslo be the study of?");
            Console.WriteLine("Options   A:Living Things B:Life C:Herbs");
            string bioTwoChoice = Console.ReadLine()!;
            if (bioTwoChoice.ToUpper() == "A")
            {
                exam.Score++;
            }
            Console.WriteLine();

            Console.WriteLine("Question 3:What is the biological habitat of a Fish?");
            Console.WriteLine("Options   A:Aboreal Habitat B:Terrestial Habitat C:Aquatic Habitat");
            string bioThreeChoice = Console.ReadLine()!;
            if (bioThreeChoice.ToUpper() == "C")
            {
                exam.Score++;
            }
            Console.WriteLine();

            Console.WriteLine("Question 4:An Organism which depends on other organisms to live is called?");
            Console.WriteLine("Options   A:Parasite B:Prey C:Pest");
            string bioFourChoice = Console.ReadLine()!;
            if (bioFourChoice.ToUpper() == "A")
            {
                exam.Score++;
            }
            Console.WriteLine();

            Console.WriteLine("Question 5:What blood cells are responsible for clotting?");
            Console.WriteLine("Options   A:Red blood cells B:White Blood cells C:Plateletes");
            string bioFiveChoice = Console.ReadLine()!;
            if (bioFiveChoice.ToUpper() == "C")
            {
                exam.Score++;
            }
            Console.WriteLine();
            Console.WriteLine("YOU HAVE SUCCESSFULLY PARTICIPATED IN THE EXAM");
            }
            else
            {
                Console.WriteLine("Cannot Participate in exam several times");
            }
            Calculations();
        }
        public void CheckGrade()
        {

        }
        public void Calculations()
        {
            double score = exam.Score;
            exam.Percentage = score / 10 * 100;
            double grade = exam.Percentage;
            GradeCalculator(grade);
            var form = _examServ.Create(exam.Score,exam.Grade,exam.Percentage);
            if(form is not null)
            {
                
            }
        }
        public void GradeCalculator(double grade)
        {
            if (grade <= 100 && grade >= 70)
            {
                exam.Grade = "A";
            }
            else if (grade <= 69 && grade >= 60)
            {
                exam.Grade = "B";
            }
            else if (grade <= 59 && grade >= 50)
            {
                exam.Grade = "C";
            }
            else if (grade <= 49 && grade >= 40)
            {
                exam.Grade = "D";
            }
            else if (grade <= 39 && grade >= 30)
            {
                exam.Grade = "E";
            }
            else
            {
                exam.Grade = "F";
            }
        }
    }
}