using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Categoria
    {
        //Llave primaria de la tabla categoria
        [Key]
        [Display(Name = "Codigo de categoria")]
        public int idcategoria { set; get; }

        [Display(Name = "Categoria")]
        [StringLength(50, ErrorMessage = "Campo {0} solo admite entre {1} y {2} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string Nombrecategoria { set; get; }

        [Display(Name = "Imagen de categoria")]
        //[StringLength(50, ErrorMessage = "Campo {0} solo admite una ruta con caracteres entre {1} y {2}", MinimumLength = 3)]
        //[Required(ErrorMessage = "Campo {0} es requerido")]
        public string imagenCat { set; get; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        //Una categoria de juegos puede contener muchos juegos
        public virtual ICollection<Juego> listaJuegos { set; get; }
    }
}