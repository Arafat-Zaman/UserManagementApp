using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Server;

[ApiController]
[Route("api/[controller]")]
public class DataSourceController : ControllerBase
{
    private readonly DataSourceProvider _dataSourceProvider;

    public DataSourceController(DataSourceProvider dataSourceProvider)
    {
        _dataSourceProvider = dataSourceProvider;
    }

    [HttpGet]
    public IActionResult GetCurrentDataSource()
    {
        return Ok(new { CurrentDataSource = _dataSourceProvider.DataSource });
    }

    //[HttpPost]
    //public IActionResult UpdateDataSource([FromBody] string newDataSource)
    //{
    //    if (string.IsNullOrEmpty(newDataSource) || (newDataSource != "SQL" && newDataSource != "JSON"))
    //    {
    //        return BadRequest("Invalid data source. Must be 'SQL' or 'JSON'.");
    //    }

    //    _dataSourceProvider.SetDataSource(newDataSource);
    //    return Ok(new { Message = $"Data source updated to {newDataSource}" });
    //}

    [HttpPost]
    public IActionResult UpdateDataSource([FromBody] string newDataSource)
    {
        if (string.IsNullOrEmpty(newDataSource) || (newDataSource != "SQL" && newDataSource != "JSON"))
        {
            return BadRequest("Invalid data source. Must be 'SQL' or 'JSON'.");
        }

        _dataSourceProvider.SetDataSource(newDataSource);
        return Ok(new { Message = $"Data source updated to {newDataSource}" });
    }

}
