using __XamlGeneratedCode__;
using fantasyleague.M;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasyleague.DB
{
    public class DbService : IDbService
    {
        SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create;
        private readonly SQLiteAsyncConnection _db;

        int xd = 0;



        string dbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "fantasyleague.db3");
        public DbService()
        {
            _db = new SQLiteAsyncConnection(dbPath, Flags);
            _db.CreateTableAsync<Player>().Wait();
            _db.CreateTableAsync<UserTeam>().Wait();

             SeedInitData().Wait();

        }


        private async Task InititalizeAsync()
        {
            await _db.CreateTableAsync<Player>();
            await _db.CreateTableAsync<UserTeam>();



        }


        private async Task SeedInitData()
        {
            xd++;

          //  var existingPlayers = await _db.Table<Player>().CountAsync();
           // if (existingPlayers == 0)
          

            //if(true)
            //{
                //var players = new List<Player>
                //{
                //    new Player { Ign = "BrokenBlade", IrlName = "Sergen Çelik", Team = "G2 Esports", Role = PlayerRole.Top, Buyingprice = 280, Sellingprice = 250, Imageurl = "g2_brokenblade.jpg" },
                //    new Player { Ign = "Yike", IrlName = "Martin Sundelin", Team = "G2 Esports", Role = PlayerRole.Jungle, Buyingprice = 270, Sellingprice = 240, Imageurl = "g2_yike.jpg" },
                //    new Player { Ign = "Caps", IrlName = "Rasmus Winther", Team = "G2 Esports", Role = PlayerRole.Mid, Buyingprice = 320, Sellingprice = 290, Imageurl = "g2_caps.jpg" },
                //    new Player { Ign = "Hans Sama", IrlName = "Steven Liv", Team = "G2 Esports", Role = PlayerRole.Adc, Buyingprice = 300, Sellingprice = 270, Imageurl = "g2_hanssama.jpg" },
                //    new Player { Ign = "Mikyx", IrlName = "Mihael Mehle", Team = "G2 Esports", Role = PlayerRole.Support, Buyingprice = 260, Sellingprice = 230, Imageurl = "g2_mikyx.jpg" },

                //    new Player { Ign = "Oscarinin", IrlName = "Óscar Muñoz", Team = "Fnatic", Role = PlayerRole.Top, Buyingprice = 220, Sellingprice = 190, Imageurl = "fnc_oscarinin.jpg" },
                //    new Player { Ign = "Razork", IrlName = "Iván Díaz", Team = "Fnatic", Role = PlayerRole.Jungle, Buyingprice = 240, Sellingprice = 210, Imageurl = "fnc_razork.jpg" },
                //    new Player { Ign = "Humanoid", IrlName = "Marek Brázda", Team = "Fnatic", Role = PlayerRole.Mid, Buyingprice = 290, Sellingprice = 260, Imageurl = "fnc_humanoid.jpg" },
                //    new Player { Ign = "Noah", IrlName = "Oh Hyeon-taek", Team = "Fnatic", Role = PlayerRole.Adc, Buyingprice = 230, Sellingprice = 200, Imageurl = "fnc_noah.jpg" },
                //    new Player { Ign = "Jun", IrlName = "Yoon Se-jun", Team = "Fnatic", Role = PlayerRole.Support, Buyingprice = 210, Sellingprice = 180, Imageurl = "fnc_jun.jpg" },
                //};

                //await _db.InsertAllAsync(players);

            //    var player = new Player { Ign = "Y", IrlName = "What", Team = "G2", Role = PlayerRole.Top, Buyingprice = 200, Sellingprice = 200, Imageurl = "kep.jpg" };
            //    await _db.InsertAsync(player);
            //}

            //var existingTeam = await _db.Table<UserTeam>().FirstOrDefaultAsync();
            //if (existingTeam == null)
            //{
            //    var userTeam = new UserTeam
            //    {
            //        Username = "Player1",
            //        Userid = "1",
            //        Budget = 1000,
            //        TeamName = "My Fantasy Team",
            //        //RosterJson = "[]" // Empty roster
            //    };
            //    await _db.InsertAsync(userTeam);
            //}


        }


        #region Player methods


        public Task<List<Player>> GetAllPlayersAsync()
        {
            return _db.Table<Player>().ToListAsync();
        }

        public Task<Player> GetPlayerByIdAsync(int id)
        {
            return _db.Table<Player>()
                      .Where(i => i.Id == id)
                      .FirstOrDefaultAsync();
        }

        public Task<List<Player>> GetPlayersByRoleAsync(PlayerRole role)
        {
            return _db.Table<Player>()
                      .Where(i => i.Role == role)
                      .ToListAsync();
        }

        public Task<List<Player>> GetPlayerByPriceAsync(int minprice, int maxprice)
        {
            return _db.Table<Player>()
                      .Where(i => i.Buyingprice >= minprice && i.Buyingprice <= maxprice)
                      .ToListAsync();
        }


        public Task<int> SavePlayerAsync(Player player)
        {
            if (player.Id != 0)
            {
                return _db.UpdateAsync(player);
            }
            else
            {
                return _db.InsertAsync(player);
            }
        }

        public Task<int> DeletePlayerAsync(Player player)
        {
            return _db.DeleteAsync(player);
        }






        #endregion

        #region UserTeam methods




        public async Task<UserTeam> GetUserTeamAsync()
        {
            return await _db.Table<UserTeam>().FirstOrDefaultAsync()
                   ?? new UserTeam { Budget = 1000 }; //, RosterJson = "[]"
        }

        public async Task SaveUserTeamAsync(UserTeam userTeam)
        {
            await _db.InsertOrReplaceAsync(userTeam);
        }





        #endregion

    }
}
