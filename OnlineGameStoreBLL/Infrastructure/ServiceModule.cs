using Autofac;
using AutoMapper;
using OnlineGameStoreDAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreBLL.Infrastructure
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DALModule());
            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile)).As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
        }
    }
}
