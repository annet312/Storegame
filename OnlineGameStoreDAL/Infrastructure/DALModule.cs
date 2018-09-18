using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineGameStoreDAL.Context;
using OnlineGameStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreDAL.Infrastructure
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IUnitOfWork>().As<IUnitOfWork>();

            const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=OnlineGameStore;Trusted_Connection=True;";

            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<StoreDbContext>();
                opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("OnlineGameStore"));

                return new StoreDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }   
    }


}
