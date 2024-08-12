using DataLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IServices;
using System.Threading.Tasks;

[Authorize]
public class FormController : Controller
{
    private readonly IFormListService _formService;
    private readonly IUserService _userService;

    public FormController(IFormListService formService, IUserService userService)
    {
        _formService = formService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var forms = await _formService.GetFormsAsync();
        return View(forms);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var form = await _formService.GetFormByIdAsync(id);
        if (form == null)
        {
            return NotFound();
        }
        return View(form);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FormList formList)
    {
        var user = await _userService.GetUserByUserName(User.Identity.Name);
        var form = new FormList
        {
            Name = formList.Name,
            Description = formList.Description,
            CreatedDate = DateTime.Now,
            CreatedBy = user.Id,
            FormFields = formList.FormFields.Select(x => new FormField
            {
                Name = x.Name,
                DataType = x.DataType,
                Required = x.Required
            }).ToList()
        };

        await _formService.CreateFormAsync(form);

        return RedirectToAction("Index");
    }
}
