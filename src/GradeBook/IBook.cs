namespace GradeBook
{
    public interface IBook
        {
            void AddGrade(double grade, string subject_name);
            Statistics GetStatistics();
            string Name {get; set;}
            event GradeAddedDelegate GradeAdded;
        }    
}