namespace Academix.GCommon.ApplicationValidation
{
    public static class ApplicationValidationConstants
    {
        public static class Subject
        {
            public const int SubjectNameMinLength = 2;
            public const int SubjectNameMaxLength = 100;

            public const int SubjectDescriptionMinLength = 5;
            public const int SubjectDescriptionMaxLength = 500;
        }
        public static class StudyTask
        {
            public const int StudyTaskTitleMinLength = 5;
            public const int StudyTaskTitleMaxLength = 120;

            public const int StudyTaskDescriptionMinLength = 5;
            public const int StudyTaskDescriptionMaxLength = 500;
        }
        public static class Exam
        {
            public const int ExamTitleMinLength = 5;
            public const int ExamTitleMaxLength = 150;

            //public const int ExamGradeMinValue = 2;
            //public const int ExamGradeMaxValue = 6;


        }
    }
}
