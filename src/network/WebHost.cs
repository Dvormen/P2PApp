using P2PApp.src.accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PApp.src.network
{
    internal class WebHost
    {
        private readonly IBankRepository _repository;

        public WebHost(IBankRepository repository)
        {
            _repository = repository;
        }

        public void Start()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapGet("/api/bank", () =>
            {
                return _repository.Load();
            });

            app.Run("http://localhost:5000");
        }
    }
}
