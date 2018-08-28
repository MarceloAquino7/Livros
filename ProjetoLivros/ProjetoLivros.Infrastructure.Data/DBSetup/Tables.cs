using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjetoLivros.Infra.Data.DBsetup
{
    enum Tables
    {
        [Description("Library")]
        Library,
        [Description("Book")]
        Book,
        [Description("Stockroom")]
        Stockroom,
        [Description("User")]
        User
    }
}
