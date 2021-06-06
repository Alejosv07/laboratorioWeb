using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Juego
    {
        //Llave primaria de la tabla juego
        [Key]
        [Display(Name = "Codigo de juego")]
        public int idjuego { set; get; }

        [Display(Name = "Nombre")]
        [StringLength(75, ErrorMessage = "Campo {0} solo admite entre {1} y {2} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public string nomJuego { set; get; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int idcategoria { set; get; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public float precio { set; get; }

        [Display(Name = "Existencias")]
        [Required(ErrorMessage = "Campo {0} es requerido")]
        public int existencias { set; get; }

        [Display(Name = "Imagen")]
        public string imagen { set; get; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //Relacion entre la tabla Categoria y juego
        public Categoria categoria { set; get; }

    }
}