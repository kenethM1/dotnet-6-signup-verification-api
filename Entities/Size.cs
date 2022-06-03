using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Size{
        [Key]
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    internal SizeDTO toDto()
    {
        return new SizeDTO{
            SizeId = Id,
            Size = Name
        };
    }
}