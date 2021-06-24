using examenDesarrollo.Context;
using examenDesarrollo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examenDesarrollo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_context.producto.Include(e => e.usuario).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var articulo = _context.producto.Include(e => e.usuario).FirstOrDefault(e => e.id == id);
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                var usuarios = _context.usuario.FirstOrDefault(t => t.id == producto.usuarioid);
                _context.Add(new Producto { nombre = producto.nombre, usuario = usuarios, usuarioid = producto.usuarioid, precio = producto.precio, descripcion = producto.descripcion, marca = producto.marca, estado =producto.estado });
                _context.SaveChanges();
                return CreatedAtRoute("GetById", new { producto.id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
