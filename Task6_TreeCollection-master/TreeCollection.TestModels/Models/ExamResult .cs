using System;
using TreeCollection.TestModels.Enums;

namespace TreeCollection.TestModels.Models
{
    public class ExamResult : IComparable<ExamResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }
        public Score Score { get; set; }
        public DateTime Date { get; set; }

        public ExamResult(int id, string name, Exams exam, Score score, DateTime date)
        {
            Id = id;
            Name = name;
            Exam = exam;
            Score = score;
            Date = date;
        }

        public int CompareTo(ExamResult other)
        {
            // Compare based on student's name
            int nameComparison = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
            if (nameComparison != 0)
                return nameComparison;

            // If names are the same, compare based on exam date
            int dateComparison = Date.CompareTo(other.Date);
            if (dateComparison != 0)
                return dateComparison;

            // If names and exam dates are the same, compare based on ID
            return Id.CompareTo(other.Id);
        }
    }
}
