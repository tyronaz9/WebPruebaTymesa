using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaTymesa.Models;

namespace WebPruebaTymesa.Data
{

   
    public static class DbInitializer
    {
                


        public static void Initialize(ApplicationDbContext context)
        {
            string _error;
            try
            {                
               context.Database.EnsureCreated();





                if (context.Pacientes.Any())
                {
                      return;   // DB has been seeded
                }

                var paciente = new Pacientes[]
                {
                     new Pacientes{ Prefijo = "Ing.",Nombre ="Tyron",Apellido ="Mejia",Direccion="Quito",Altura=(float)1.70,Email="tyronaz9@hotmail.com",Estado="S",Peso=100,Sexo="M",Telefono="0987003325",Activo=false},
                     new Pacientes{ Prefijo = "",Nombre ="Pedro",Apellido ="Mera",Direccion="Ambato",Altura=(float)1.50,Email="tyronaz9@hotmail.com",Estado="S",Peso=88,Sexo="M",Telefono="0987003325",Activo=false},
                     new Pacientes{ Prefijo = "Dr.",Nombre ="Betty",Apellido ="Cruz",Direccion="Quito",Altura=(float)1.50,Email="tyronaz9@hotmail.com",Estado="S",Peso=60,Sexo="F",Telefono="0977003326",Activo=true},
                     new Pacientes{ Prefijo = "Ab.",Nombre ="Jorge",Apellido ="MAcias",Direccion="Ibarra",Altura=(float)1.60,Email="tyronaz9@hotmail.com",Estado="S",Peso=95,Sexo="M",Telefono="0987033322",Activo=true},
                     new Pacientes{ Prefijo = "Ing.",Nombre ="Miguel",Apellido ="Zambrano",Direccion="Manta",Altura=(float)1.67,Email="tyronaz9@hotmail.com",Estado="c",Peso=100,Sexo="M",Telefono="0958003325",Activo=true},
                     new Pacientes{ Prefijo = "Ec.",Nombre ="Manuel",Apellido ="Lopez",Direccion="Quito",Altura=(float)1.80,Email="tyronaz9@hotmail.com",Estado="V",Peso=103,Sexo="M",Telefono="0981033315",Activo=true},
                     new Pacientes{ Prefijo = "Arq.",Nombre ="Luis",Apellido ="Cabrera",Direccion="Quito",Altura=(float)1.70,Email="tyronaz9@hotmail.com",Estado="S",Peso=100,Sexo="M",Telefono="0957003320",Activo=false},
                     new Pacientes{ Prefijo = "",Nombre ="Rossana",Apellido ="Mejia",Direccion="Quito",Altura=(float)1.60,Email="tyronaz9@hotmail.com",Estado="D",Peso=80,Sexo="F",Telefono="0987143305",Activo=true},
                     new Pacientes{ Prefijo = "Ing.",Nombre ="Juan",Apellido ="Barcia",Direccion="Quito",Altura=(float)1.63,Email="tyronaz9@hotmail.com",Estado="S",Peso=95,Sexo="M",Telefono="0987003344",Activo=false},
                     new Pacientes{ Prefijo = "Ing.",Nombre ="Marcelo",Apellido ="Mora",Direccion="Quito",Altura=(float)1.50,Email="tyronaz9@hotmail.com",Estado="S",Peso=100,Sexo="M",Telefono="0989093329",Activo=true},

                };

                foreach (Pacientes s in paciente)
                {
                    context.Pacientes.Add(s);
                }
                context.SaveChanges();



                if (context.Medicinas.Any())
                {
                    return;   // DB has been seeded
                }
                              

                var medicina = new Medicinas[]
                {
                new Medicinas{Nombre="Apronax",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="Paracetamol",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="Aspirina",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="GYNO CANESTEN  200 MG * 3 OVULOS BLANDOS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ABANIX SUSP. 100 MG * 30 ML",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ABANIX 200 MG * 6 TABLETAS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AGUA DESTILADA G.M. ESTERIL * 10 ML",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ADORLAN * 30 COMPRIMIDOS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ACNECLIN  50 MG * 30 COMP. RECUB.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ACICLOVIR G-A 400 MG * 10 TABL. DISP.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AMOXICILINA G-A SUSP. 500 MG/5 ML * 100 ML.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="FLUSAM JARABE * 120 ML.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AMIKACINA G-A SOL. INY. 500 MG * 1 AMPOLLA",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AMIKACINA G-A SOL. INY. 100 MG * 1 AMPOLLA",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AMPICILINA G-A INY.   1 GR * 10 AMPOLLAS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="CURE BAND CURITAS REDONDAS * 100 UNI",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="LOSARTAN POTASICO LA SANTE  50 MG. * 30 TABLETAS RECUBIERTAS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ACETAGEN 1 GR * 20 COMPRIMIDOS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="HEPALIVE FORTE + COENZIMA Q 10 * 30 CAPSULAS (+ 10 CAPSULAS GRATIS)",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ALGODON SANA *  15 GRS",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ABRILAR 65 MG * 10 COMP. EFERVESENTES",Activo=false,Cobrable=true,Generico =false},
                new Medicinas{Nombre="ACEITE DE RECINO WEIR PAQUETE * 12 FCOS DE 30 ML C/U",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="BUPREX FLASH 400 MG * 10 CAP. LIQ.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="AMOXIL SUSPENSION 250 MG/5 ML * 120 ML.",Activo=true,Cobrable=true,Generico =true},
                new Medicinas{Nombre="ALGODON SANA *  60 GRS. (F'S)",Activo=false,Cobrable=true,Generico =true},
              
                };
                foreach (Medicinas s in medicina)
                {
                    context.Medicinas.Add(s);
                }
                context.SaveChanges();

                if (context.Prescripciones.Any())
                {
                    return;   // DB has been seeded
                }



                var prescipcion = new Prescripciones[]
              {
                 new Prescripciones{ PacientesID=1,MedicinasID=1,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=1,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=DateTime.Parse("15/04/2022")},
                 new Prescripciones{ PacientesID=1,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=1,MedicinasID=10,FechaIni=DateTime.Parse("15/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=1,MedicinasID=8,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=1,MedicinasID=1,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=2,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=DateTime.Parse("15/04/2022")},
                 new Prescripciones{ PacientesID=2,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=2,MedicinasID=10,FechaIni=DateTime.Parse("15/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=2,MedicinasID=8,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=3,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=DateTime.Parse("15/04/2022")},
                 new Prescripciones{ PacientesID=3,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=3,MedicinasID=10,FechaIni=DateTime.Parse("15/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=3,MedicinasID=8,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=4,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=DateTime.Parse("15/04/2022")},
                 new Prescripciones{ PacientesID=4,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=4,MedicinasID=10,FechaIni=DateTime.Parse("15/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=4,MedicinasID=8,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=5,MedicinasID=8,FechaIni=DateTime.Parse("15/04/2022"),FechaFin=DateTime.Parse("18/04/2022")},
                 new Prescripciones{ PacientesID=5,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=DateTime.Parse("15/04/2022")},
                 new Prescripciones{ PacientesID=5,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=null},
                 new Prescripciones{ PacientesID=5,MedicinasID=10,FechaIni=DateTime.Parse("17/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=6,MedicinasID=8,FechaIni=DateTime.Parse("18/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=6,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=6,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=null},
                 new Prescripciones{ PacientesID=6,MedicinasID=10,FechaIni=DateTime.Parse("17/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=7,MedicinasID=8,FechaIni=DateTime.Parse("18/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=7,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=7,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=null},
                 new Prescripciones{ PacientesID=7,MedicinasID=10,FechaIni=DateTime.Parse("17/04/2021"),FechaFin=null},
                 new Prescripciones{ PacientesID=8,MedicinasID=8,FechaIni=DateTime.Parse("18/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=8,MedicinasID=2,FechaIni=DateTime.Parse("10/04/2022"),FechaFin=null},
                 new Prescripciones{ PacientesID=8,MedicinasID=3,FechaIni=DateTime.Parse("01/04/2020"),FechaFin=null},
                 new Prescripciones{ PacientesID=8,MedicinasID=10,FechaIni=DateTime.Parse("17/04/2021"),FechaFin=null},

              };

                foreach (Prescripciones s in prescipcion)
                {
                    context.Prescripciones.Add(s);
                }
                context.SaveChanges();

                if (!context.Roles.Any())
                {
                   var rol = new IdentityRole[]
                   {

                     new IdentityRole{Name="ROLE_ADMIN",NormalizedName="ROLE_ADMIN"},
                     new IdentityRole{Name="ROLE_USER",NormalizedName="ROLE_USER"},
                   };
                    foreach (IdentityRole s in rol)
                    {
                        context.Roles.Add(s);
                    }
                    context.SaveChanges();
                }
                              


                    // Look for any students.
                if (!context.Users.Any())
                {
                    var user = new IdentityUser[]
                    {
                     new IdentityUser{Email="admin@gmail.com",UserName="Admin",PasswordHash="AQAAAAEAACcQAAAAEGyEZgmeKAWG+QXId0vebAbrKlOGlmXs1fQomUGShsu9bsIRNo7GLdaWrdRZ4DYKkg==",LockoutEnabled=true,EmailConfirmed=true,NormalizedEmail="admin@gmail.com",NormalizedUserName="Admin"},
                     new IdentityUser{Email="usuario@gmail.com",UserName="Usuario",PasswordHash="AQAAAAEAACcQAAAAEGyEZgmeKAWG+QXId0vebAbrKlOGlmXs1fQomUGShsu9bsIRNo7GLdaWrdRZ4DYKkg==",LockoutEnabled=true,EmailConfirmed=true,NormalizedEmail="usuario@gmail.com",NormalizedUserName="Usuario"},
                     new IdentityUser{Email="cliente@gmail.com",UserName="Cliente",PasswordHash="AQAAAAEAACcQAAAAEGyEZgmeKAWG+QXId0vebAbrKlOGlmXs1fQomUGShsu9bsIRNo7GLdaWrdRZ4DYKkg==",LockoutEnabled=true,EmailConfirmed=true,NormalizedEmail="cliente@gmail.com",NormalizedUserName="Cliente"}
                    };

                    foreach (IdentityUser s in user)
                    {
                        context.Users.Add(s);
                    }
                    context.SaveChanges();
                }



                if (!context.UserRoles.Any())
                {
                    var _role = context.Roles.Where(r => r.Name == "ROLE_ADMIN").FirstOrDefault();
                    var _user = context.Users.Where(r => r.UserName == "Admin").FirstOrDefault();
                    var role = new IdentityUserRole<string>
                    {
                        RoleId = _role.Id,
                        UserId = _user.Id
                    };

                    context.UserRoles.Add(role);


                    _role = context.Roles.Where(r => r.Name == "ROLE_USER").FirstOrDefault();
                    _user = context.Users.Where(r => r.UserName == "Cliente").FirstOrDefault();
                    role = new IdentityUserRole<string>
                    {
                        RoleId = _role.Id,
                        UserId = _user.Id
                    };

                    context.UserRoles.Add(role);

                    _user = context.Users.Where(r => r.UserName == "Usuario").FirstOrDefault();
                    role = new IdentityUserRole<string>
                    {
                        RoleId = _role.Id,
                        UserId = _user.Id
                    };

                    context.UserRoles.Add(role);

                    context.SaveChanges();
                }


                /*  if (!context.RoleClaims.Any())
                  {

                      var _role = context.Roles.Where(r => r.Name == "ROLE_ADMIN").FirstOrDefault();

                      var role = new IdentityRoleClaim<string>
                      {
                          RoleId = _role.Id,

                      };

                      context.RoleClaims.Add(role);

                    //  context.SaveChanges();
                  }*/


                /* if (!context.UserClaims.Any())
                 {


                     var _user = context.Users.Where(r => r.UserName == "Admin").FirstOrDefault();
                     var role = new IdentityUserClaim<string>
                     {
                         UserId = _user.Id,

                     };

                     context.UserClaims.Add(role);

                     context.SaveChanges();
                 }*/


                if (!context.Tipos.Any())
                {
                    var tipo = new Tipos[]
                    {

                     new Tipos{Tipo="Débito",Sigla="D",Signo=1},
                     new Tipos{Tipo="Crédito",Sigla="C",Signo=-1},
                    };
                    foreach (Tipos s in tipo)
                    {
                        context.Tipos.Add(s);
                    }
                    context.SaveChanges();
                }


                if (context.Clientes.Any())
                {
                    return;   // DB has been seeded
                }                                   
         

                var cliente = new Clientes[]
                {
                new Clientes{Nombre="Tyron Mejia",Direccion="Quito",Telefono="0987003329",UserName = "Usuario"},
                new Clientes{Nombre="Betty Cruz",Direccion="Manta",Telefono="0987003324",UserName = "Cliente"},
            
                };
                foreach (Clientes s in cliente)
                {
                    context.Clientes.Add(s);
                }
                context.SaveChanges();


               

            }
            catch (Exception ex)
            {

                _error = ex.Message;
            }

        }
    }
}
