using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using UpSchool_SignalR_Api2.Models;

namespace UpSchool_SignalR_Api2.Hubs
{
    public class ElectricService
    {
        private readonly Context _contex;
        private readonly IHubContext<ElectricHub> _hubContext;

        public ElectricService(Context context, IHubContext<ElectricHub> hubContext)
        {
            _contex = context;
            _hubContext = hubContext;
        }

        public IQueryable<Electric> GetList() // IQueryable bize database vb. veri depolarında yapılan sorgulamalar da işlevsellik sağlar
                                              //IQueryable ise öncelikle belirtiğimiz koşula göre bir sorgu uygulayıp bunula database’e gidiyor gerekli verileri aldıktan sonra bize dönüş sağlıyor.
        {
            return _contex.Electrics.AsQueryable();
        }

        public async Task SaveElectric(Electric electric)
        {
            await _contex.Electrics.AddAsync(electric);
            await _contex.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveElectricList", "data");
        }

        public void SaveElectric(object newElectric)
        {
            throw new NotImplementedException();
        }
    }
}
