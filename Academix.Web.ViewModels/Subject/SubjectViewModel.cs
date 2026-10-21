namespace Academix.Web.ViewModels.Subject
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsAdded { get; set; }

    }
}
