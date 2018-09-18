using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineGameStoreDAL.Entities
{
    public class Game
    {

        public int Id { get; set; }

        //public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public IList<GameGenre> GameGenres { get; set; }
    }
}
