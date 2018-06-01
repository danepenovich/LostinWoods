using LostInWoodsDemo.Models;
using System.Collections.Generic;
namespace LostInWoodsDemo.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}