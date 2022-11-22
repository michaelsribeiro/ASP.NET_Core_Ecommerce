using System.ComponentModel.DataAnnotations;

namespace ToolsMarket.App.Data
{
    public class ApplicationUser
    {
        [Key]
        public Guid Id { get; set; }             
    }
}
