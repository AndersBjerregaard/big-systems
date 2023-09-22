using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace exampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookRepository _repo;

    public BookController(BookRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repo.Books);
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var book = _repo.Books.FirstOrDefault(x => x.Id == id);
        if (book is null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        var createdBook = book;
        _repo.Books.Add(createdBook);
        return CreatedAtAction(nameof(Get), createdBook.Id);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Book book)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
