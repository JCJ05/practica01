using Microsoft.AspNetCore.Mvc;
using practica01.Models;
using practica01.Data;
using System.Linq;



namespace practica01.Controllers
{
    public class ProductoController:Controller
    {

    private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult Guardar(Producto producto) {

             _context.Add(producto);
            _context.SaveChanges();
             
             ViewData["Mensaje"] = "La venta se guardo con exito";

             return View("Views/Home/Index.cshtml");


        }

        public IActionResult Listar () {

            return View("Views/Producto/Listar.cshtml" ,_context.DataProductos.ToList());
        }

        public IActionResult Editar(int id) {

            Producto producto = _context.DataProductos.Find(id);

            if(producto == null) {
            
                 return NotFound();

            }

            return View("Views/Producto/Editar.cshtml",producto);

        }
       
         [HttpPost]
        public IActionResult Editar(int id,[Bind("Id,nombre,precio,categoria,descuento")] Producto producto)
        {
             _context.Update(producto);
             _context.SaveChanges();
              ViewData["Mensaje"] = "La venta se actualizo con exito";
             return View("Views/Producto/Editar.cshtml" , producto);
        }
       
          public IActionResult Eliminar(int id)
        {
            Producto producto = _context.DataProductos.Find(id);
            _context.DataProductos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Listar));
        }
        
    }
}