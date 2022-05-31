using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CristianMorocho.Models
{
    public class Students
    {
        [PrimaryKey, AutoIncrement]
        public int cod_estudiante { get; set; }
        [MaxLength(25)]
        public string nombre { get; set; }
        [MaxLength(25)]
        public string apellido { get; set; }
        [MaxLength(25)]
        public string curso { get; set; }
        [MaxLength(1)]
        public string paralelo { get; set; }
        public float nota_final { get; set; }
    }
}
