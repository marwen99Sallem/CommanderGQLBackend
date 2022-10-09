using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models;

    public class Platform
    {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string? LicenceKey { get; set; }

    public ICollection<Command> commands { get; set; }=new List<Command>();

}

