﻿using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface iAdminstradorServico
    {
        Administrador Login(LoginDTO loginDTO);
    }
}
