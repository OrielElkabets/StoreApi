using StoreApi.Entities.StoreDb.EOs;

namespace StoreApi.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Qty { get; set; }
        public required float Price { get; set; }
        public string? Description { get; set; }

        public static ItemDTO FromEO(ItemsEO item)
        {
            return new()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Qty = item.Qty,
                Description = item.Description
            };
        }
    }

    public class NewItemDTO
    {
        public required string Name { get; set; }
        public required int Qty { get; set; }
        public required float Price { get; set; }
        public string? Description { get; set; }

        public ItemsEO ToEO()
        {
            return new()
            {
                Name = Name,
                Qty = Qty,
                Price = Price,
                Description = Description
            };
        }
    }

    public class UpdateItemDTO
    {
        public required string Name { get; set; }
        public required int Qty { get; set; }
        public required float Price { get; set; }
        public string? Description { get; set; }

        public ItemsEO UpdateEO(ItemsEO item)
        {
            item.Name = Name;
            item.Qty = Qty;
            item.Price = Price;
            item.Description = Description;
            return item;
        }
    }
}
