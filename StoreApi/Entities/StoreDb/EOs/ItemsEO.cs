using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace StoreApi.Entities.StoreDb.EOs
{
    // Entity Object
    public class ItemsEO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Qty { get; set; }
        public required float Price { get; set; }
        public string? Description { get; set; }
    }
}
