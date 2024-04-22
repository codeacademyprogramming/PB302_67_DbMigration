namespace Eterna.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }  
        public string Name { get; set; }
        public bool IsPoster { get; set; }
        public Project Project { get; set; }    
    }
}
