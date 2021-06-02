using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultsRecorder
{
    class Module
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Assessment1 { get; set; }
        public string Assessment2 { get; set; }
        public bool SingleAssessment { get; set; }

        public double ConvertGrade(string Grade)
        {
            switch (Grade)
            {
                case "A+":
                    return 25.0;
                case "A":
                    return 23.0;
                case "A-":
                    return 21.0;
                case "B+":
                    return 20.0;
                case "B":
                    return 19.0;
                case "B-":
                    return 18.0;
                case "C+":
                    return 17.0;
                case "C":
                    return 16.0;
                case "C-":
                    return 15.0;
                case "D+":
                    return 14.0;
                case "D":
                    return 13.0;
                case "D-":
                    return 12.0;
                case "F+":
                    return 11.0;
                case "F":
                    return 8.0;
                case "F-":
                    return 4.0;
                default:
                    return 0.0;
            }
        }

        public string ConvertGrade(double Grade)
        {
            if (Grade >= 24.0)
                return "A+";
            else if (Grade >= 22.0)
                return "A";
            else if (Grade >= 20.50)
                return "A-";
            else if (Grade >= 19.50)
                return "B+";
            else if (Grade >= 18.50)
                return "B";
            else if (Grade >= 17.50)
                return "B-";
            else if (Grade >= 16.50)
                return "C+";
            else if (Grade >= 15.50)
                return "C";
            else if (Grade >= 14.50)
                return "C-";
            else if (Grade >= 13.50)
                return "D+";
            else if (Grade >= 12.50)
                return "D";
            else if (Grade >= 11.50)
                return "D-";
            else if (Grade >= 9.50)
                return "F+";
            else if (Grade >= 6.00)
                return "F";
            else if (Grade >= 2.00)
                return "F-";
            else
                return "G";
        }

        public string CalculateGrade()
        {
            return (ConvertGrade((ConvertGrade(Assessment1) + ConvertGrade(Assessment2)) / 2));
        }
    }
}
