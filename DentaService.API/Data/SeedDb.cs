using DentaService.API.Data.Entities;
using DentaService.API.Helpers;
using DentaService.Common.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckDetailServicesAsync();
            await CheckDiagnosticsAsync();
            await CheckEquipmentAsync();
            await CheckEspecializationsAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "cedula", "Sebastian", "Alzate", "sebas@yopmail.com", "304 249 2232", "Calle 40 105 146", UserType.Dentist);
            await CheckUserAsync("2020", "cedula", "Juan", "Zuluaga", "zulu@yopmail.com", "304 322 4620", "Calle luna Calle sol", UserType.Client);
            await CheckUserAsync("3030", "cedula", "Daniela", "Sanchez", "dani@yopmail.com", "304 234 5679", "Calle 32 456 432", UserType.Client);


        }

        private async Task CheckUserAsync(string document,string documentType, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if(user == null)
            {
                user = new User
                {
                    Adress = address,
                    Document = document,
                    DocumentType= documentType,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType

                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Dentist.ToString());
            await _userHelper.CheckRoleAsync(UserType.Client.ToString());
        }

        private async Task CheckDetailServicesAsync()
        {
            if (!_context.DetailServices.Any())
            {

                _context.DetailServices.Add(new DetailService { PaymentMethod = "Tarjeta Credito" });
                _context.DetailServices.Add(new DetailService { PaymentMethod = "Tarjeta Debito" });
                _context.DetailServices.Add(new DetailService { PaymentMethod = "Efectivo" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDiagnosticsAsync()
        {
            if (!_context.Diagnostics.Any())
            {

                _context.Diagnostics.Add(new Diagnostic
                {
                    Remark = "El paciente ingresa por una consulta general, se determina" +
                             " los siguientes procedimientos que se debe realizar: -limpieza general y calzas;" +
                             " -el paciente se desea realizar un diseño de sonrisa. Se requiere relizar una ortodoncia."
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEquipmentAsync()
        {
            if (!_context.Equipments.Any())
            {
                _context.Equipments.Add(new Equipment { Description = "Silicona de adicion" });
                _context.Equipments.Add(new Equipment { Description = "Guantes Desechables" });
                _context.Equipments.Add(new Equipment { Description = "Servilletas" });
                _context.Equipments.Add(new Equipment { Description = "Brackets" });
                _context.Equipments.Add(new Equipment { Description = "Agujas" });
                _context.Equipments.Add(new Equipment { Description = "Anestesia" });
                _context.Equipments.Add(new Equipment { Description = "Papel de articular" });
                _context.Equipments.Add(new Equipment { Description = "Mascarilla" });
                _context.Equipments.Add(new Equipment { Description = "Babero" });
                _context.Equipments.Add(new Equipment { Description = "Gafas" });
                _context.Equipments.Add(new Equipment { Description = "Producto de desinfección" });


                await _context.SaveChangesAsync();
            }
        }



        private async Task CheckEspecializationsAsync()
        {
            if (!_context.Especializations.Any())
            {
                _context.Especializations.Add(new Especialization { Description = "Periodontista" });
                _context.Especializations.Add(new Especialization { Description = "Ortodoncista" });
                _context.Especializations.Add(new Especialization { Description = "Endodoncista" });
                _context.Especializations.Add(new Especialization { Description = "Odontologo General" });
                _context.Especializations.Add(new Especialization { Description = "Prostodoncista" });
                _context.Especializations.Add(new Especialization { Description = "Odontopediatra" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
