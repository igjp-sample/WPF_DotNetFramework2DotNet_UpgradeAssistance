using Infragistics.Documents.Excel;
using ScoreSheets_SampleWPFApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreSheets_SampleWPFApplication.DataService
{
    internal class DataSourceWrapper
    {
        private static String _scoreDataFilePath = @".\Data\成績データ.xlsx";

        internal static (List<Grade>, List<List<Student>>, List<List<SubjectAndFrequencyData>>) GetAllStudentsData()
        {
            var grades = new List<Grade>();
            var allstudents = new List<List<Student>>();
            var allFrequencies = new List<List<SubjectAndFrequencyData>>();

            Workbook workbook = Workbook.Load(_scoreDataFilePath);
            foreach (var (worksheet, worksheetIndex) in workbook.Worksheets.Select((value, index) => (value, index)))
            {
                grades.Add(new Grade() { DisplayText = worksheet.Name, IndexInListData = worksheetIndex });

                var students = new List<Student>();
                allstudents.Add(students);

                var frequencies = new List<SubjectAndFrequencyData>()
                {
                    new SubjectAndFrequencyData() { Subject = "国語" },
                    new SubjectAndFrequencyData() { Subject = "数学" },
                    new SubjectAndFrequencyData() { Subject = "英語" },
                    new SubjectAndFrequencyData() { Subject = "社会" },
                    new SubjectAndFrequencyData() { Subject = "理科" },
                };
                foreach (var freq in frequencies)
                {
                    freq.Frequencies = new List<Frequency>()
                    {
                        new Frequency() { ClassThreshold = 10, ClassDisplayText = " ～9" },
                        new Frequency() { ClassThreshold = 20, ClassDisplayText = " ～19" },
                        new Frequency() { ClassThreshold = 30, ClassDisplayText = " ～29" },
                        new Frequency() { ClassThreshold = 40, ClassDisplayText = " ～39" },
                        new Frequency() { ClassThreshold = 50, ClassDisplayText = " ～49" },
                        new Frequency() { ClassThreshold = 60, ClassDisplayText = " ～59" },
                        new Frequency() { ClassThreshold = 70, ClassDisplayText = " ～69" },
                        new Frequency() { ClassThreshold = 80, ClassDisplayText = " ～79" },
                        new Frequency() { ClassThreshold = 90, ClassDisplayText = " ～89" },
                        new Frequency() { ClassThreshold = 101, ClassDisplayText = " ～100" },
                    };
                }
                allFrequencies.Add(frequencies);

                foreach (var (row, rowIndex) in worksheet.Rows.Select((value, index) => (value, index)))
                {
                    if (rowIndex < 1) continue;
                    var student = new Student()
                    {
                        ID = row.Cells[0].Value.ToString(),
                        Name = row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString(),
                        NameYomi = row.Cells[3].Value.ToString() + " " + row.Cells[4].Value.ToString(),
                        Japanese = Int32.Parse(row.Cells[5].Value.ToString()),
                        Mathmatics = Int32.Parse(row.Cells[6].Value.ToString()),
                        English = Int32.Parse(row.Cells[7].Value.ToString()),
                        Science = Int32.Parse(row.Cells[8].Value.ToString()),
                        SocialStudies = Int32.Parse(row.Cells[9].Value.ToString())
                    };
                    students.Add(student);

                    frequencies.FirstOrDefault(freq => freq.Subject == "国語").Frequencies.FirstOrDefault(freq => student.Japanese < freq.ClassThreshold).Count++;
                    frequencies.FirstOrDefault(freq => freq.Subject == "数学").Frequencies.FirstOrDefault(freq => student.Mathmatics < freq.ClassThreshold).Count++;
                    frequencies.FirstOrDefault(freq => freq.Subject == "英語").Frequencies.FirstOrDefault(freq => student.English < freq.ClassThreshold).Count++;
                    frequencies.FirstOrDefault(freq => freq.Subject == "社会").Frequencies.FirstOrDefault(freq => student.SocialStudies < freq.ClassThreshold).Count++;
                    frequencies.FirstOrDefault(freq => freq.Subject == "理科").Frequencies.FirstOrDefault(freq => student.Science < freq.ClassThreshold).Count++;
                }
            }

            return (grades, allstudents, allFrequencies);
        }
    }
}
