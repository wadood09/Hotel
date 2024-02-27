using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentFile_Project.Model.Entities
{
    public class Exam : BaseEntities
    {
        public string Type{get;set;} = default!;
        public double Percentage{get;set;}
        public string Grade{get;set;} = default!;
        public string StudentId{get;set;} = default!;
        public double Score{get;set;}

        //   public override string ToString()
        // {
        //     return $"{BiologyScore}\t{ChemistryScore}\t{Percentage}\t{Grade}";
        // }

        // public Exam (double chemistryScore,double biologyScore,double percentage,string grade)
        // {
        //     ChemistryScore = chemistryScore;
        //     BiologyScore = biologyScore;
        //     Grade = grade;
        //     Percentage = percentage;
        // }

        // public  Exam ToExam (string str)
        // {
        //     var model = str.Split('\t');
        //     return new Exam(double.Parse(model[0]),double.Parse(model[1]),double.Parse(model[2]),model[3] );
            
        // }
    }
    
    
}