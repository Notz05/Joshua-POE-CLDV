using Microsoft.AspNetCore.Mvc;

namespace Joshua_POE_CLDV.Controllers { }


[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartController(DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet] 
    public async Task<IActionResult> GetCartItems()
    {
        var sessionId = GetSessionId();
        var cartItems = await _context.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.SessionId == sessionId)
            .ToListAsync();
        return Ok(cartItems);
    }

    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToCart(int productId)
    {
        var sessionId = GetSessionId();
        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.SessionId == sessionId);

        if (cartItem == null)
        {
            cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = 1,
                SessionId = sessionId
            };
            _context.CartItems.Add(cartItem);
        }
        else
        {
            cartItem.Quantity++;
            _context.CartItems.Update(cartItem);
        }

        await _context.SaveChangesAsync();
        return Ok(cartItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var cartItem = await _context.CartItems.FindAsync(id);
        if (cartItem == null)
        {
            return NotFound();
        }

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private string GetSessionId()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        if (session.GetString("SessionId") == null)
        {
            session.SetString("SessionId", Guid.NewGuid().ToString());
        }
        return session.GetString("SessionId");
    }
}

