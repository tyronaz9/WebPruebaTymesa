using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaTymesa.Data
{
    public class Funciones
    {        

        public bool Rol(ApplicationDbContext context,string Rol,string Usuario)
        {
            bool resultado = true;
            var listado = (from user in context.Users
                                join userRoles in context.UserRoles on user.Id equals userRoles.UserId
                                join role in context.Roles on userRoles.RoleId equals role.Id
                           where role.Name == Rol && user.UserName == Usuario
                                select new { UserId = user.Id, UserName = user.UserName, RoleId = role.Id, RoleName = role.Name })
                        .ToList();
            if (listado.Count == 0)
            {
                resultado = false;
            }
            return resultado;
        }
      

    }
}
