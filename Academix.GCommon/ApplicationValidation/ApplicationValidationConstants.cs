namespace Academix.GCommon.ApplicationValidation
{
    public static class ApplicationValidationConstants
    {
        public static class Subject
        {
            public const string SubjectRemovedSuccessfully = "Subject removed successfully!";
            public const string SubjectAddedSuccessfully = "Subject added successfully!";
        }

        public static class StudyTask
        {
            public const string StudyTaskFutureDateErrorMessage = "Date cannot be in the past.";
        }

        public static class Exam
        {
            public const string ExamFutureDateErrorMessage = "Exam date must be in the future.";
        }

        public static class ErrorMessages
        {
            public const string UnexpectedError = "An unexpcted error occurred.";
            public const string AccessDenied = "You do not have permission to do this action.";
            public const string NotFound = "The requested item was not found.";

            // Study Tasks //
            public const string StudyTaskCreationFailed =
                "Failed to create study task.";

            public const string StudyTaskEditFailed =
                "Failed to edit study task.";

            public const string StudyTaskDeleteFailed =
                "Failed to delete study task.";

            // Exams //
            public const string ExamCreationFailed =
                "Unable to create exam for this subject.";

            public const string ExamEditFailed =
                "Unable to edit exam.";

            public const string ExamDeleteFailed =
                "Unable to delete exam.";

            // Subjects //
            public const string SubjectAddFailed =
                "Unable to add subject.";

            public const string SubjectRemoveFailed =
                "Unable to remove subject.";
        }
    }
}
