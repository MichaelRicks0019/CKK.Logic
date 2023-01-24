using CKK.DB.Interfaces;
using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        Order Order { get; set; }
        IUnitOfWork UOW { get; set; }
    }
}
