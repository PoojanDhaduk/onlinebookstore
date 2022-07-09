using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.models.ViewModels;
using BookStore.models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.repository
{
    public class CartRepository { 
     testContext _context = new testContext();
    public List<Cart> GetCartItems(string keyword)
    {
        keyword = keyword?.ToLower()?.Trim();
        var query = _context.Carts.Include(c=>c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();
            return query.ToList();
    }
    public Cart GetCart(int id)
    {
        try
        {
            var check = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (check == null)
            {
                return check;
            }
            return check;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public Cart AddCart(Cart cart)
    {
        var entry = _context.Carts.Add(cart);
        _context.SaveChanges();
        return entry.Entity;
    }
    public Cart UpdateCart(Cart cart)
    {
        var entry = _context.Carts.Update(cart);
        _context.SaveChanges();
        return entry.Entity;
    }
    public Cart RemoveCart(int id)
    {
        var category = _context.Carts.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            var entry = _context.Carts.Remove(category);
            _context.SaveChanges();
            return category;
        }

        return category;
    }

}
}
