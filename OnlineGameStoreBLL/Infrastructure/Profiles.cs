using AutoMapper;
using OnlineGameStoreBLL.BLLModels;
using OnlineGameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreBLL.Infrastructure
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameBll>().ReverseMap();
        }
    }
}
