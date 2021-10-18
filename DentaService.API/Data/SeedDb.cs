using DentaService.API.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckDetailServicesAsync();
            await CheckDiagnosticsAsync();
            await CheckEquipmentAsync();
            await CheckEspecializationsAsync();


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
