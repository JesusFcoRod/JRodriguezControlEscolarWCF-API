﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int idMateria { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        public ML.Alumno Alumno { get; set; }
        public List<object> Materias { get; set; }
    }
}
