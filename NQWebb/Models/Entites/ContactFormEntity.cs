namespace NQWebb.Models.Entites
{
    public class ContactFormEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
