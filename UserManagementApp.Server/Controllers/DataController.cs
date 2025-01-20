using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    [HttpGet]
    public IActionResult GetData([FromQuery] string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return BadRequest("Data source must be specified.");
        }

        if (source.Equals("JSON", StringComparison.OrdinalIgnoreCase))
        {
            var jsonData = new
            {
                Id = 1,
                Name = "Data from JSON Source"
            };
            return Ok(jsonData);
        }
        else if (source.Equals("SQL", StringComparison.OrdinalIgnoreCase))
        {
            var sqlData = new
            {
                Id = 2,
                Name = "Data from SQL Source"
            };
            return Ok(sqlData);
        }

        return BadRequest("Invalid data source.");
    }
}
