﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Turma
    {
        public long Id { get;  set; }
        public string Nome { get;  set; }
        public Escola Escola { get;  set; }
    }
}
