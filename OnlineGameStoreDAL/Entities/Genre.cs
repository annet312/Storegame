using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineGameStoreDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; } //property is null if it is basic genre

        public IList<GameGenre> GameGenres { get; set; }
    }

    public class GameGenre
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}


