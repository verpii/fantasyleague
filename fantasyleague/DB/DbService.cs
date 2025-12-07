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

            //var User = new UserTeam
            //{
            //    Username = "Player1",
            //    Userid = "1",
            //    Budget = 1000,
            //    TeamName = "My Fantasy Team",
            //    RosterString = "[]"
            //};

            //await _db.InsertAsync(User);


            //  var existingPlayers = await _db.Table<Player>().CountAsync();
            // if (existingPlayers == 0)


//            if (true)
//            {
//                var players = new List<Player>
//                {
//                    // T1 - Korea
//new Player { Ign = "Zeus", IrlName = "Choi Woo-je", Team = "T1", Role = PlayerRole.Top, Buyingprice = 350, Sellingprice = 320, Imageurl = "t1_zeus.jpg" },
//new Player { Ign = "Oner", IrlName = "Mun Hyeon-jun", Team = "T1", Role = PlayerRole.JG, Buyingprice = 320, Sellingprice = 290, Imageurl = "t1_oner.jpg" },
//new Player { Ign = "Faker", IrlName = "Lee Sang-hyeok", Team = "T1", Role = PlayerRole.Mid, Buyingprice = 400, Sellingprice = 370, Imageurl = "t1_faker.jpg" },
//new Player { Ign = "Gumayusi", IrlName = "Lee Min-hyeong", Team = "T1", Role = PlayerRole.Adc, Buyingprice = 340, Sellingprice = 310, Imageurl = "t1_gumayusi.jpg" },
//new Player { Ign = "Keria", IrlName = "Ryu Min-seok", Team = "T1", Role = PlayerRole.Sup, Buyingprice = 330, Sellingprice = 300, Imageurl = "t1_keria.jpg" },

//// Gen.G - Korea
//new Player { Ign = "Kiin", IrlName = "Kim Ki-in", Team = "Gen.G", Role = PlayerRole.Top, Buyingprice = 330, Sellingprice = 300, Imageurl = "gen_kiin.jpg" },
//new Player { Ign = "Canyon", IrlName = "Kim Geon-bu", Team = "Gen.G", Role = PlayerRole.JG, Buyingprice = 340, Sellingprice = 310, Imageurl = "gen_canyon.jpg" },
//new Player { Ign = "Chovy", IrlName = "Jeong Ji-hoon", Team = "Gen.G", Role = PlayerRole.Mid, Buyingprice = 380, Sellingprice = 350, Imageurl = "gen_chovy.jpg" },
//new Player { Ign = "Peyz", IrlName = "Kim Su-hwan", Team = "Gen.G", Role = PlayerRole.Adc, Buyingprice = 320, Sellingprice = 290, Imageurl = "gen_peyz.jpg" },
//new Player { Ign = "Lehends", IrlName = "Son Si-woo", Team = "Gen.G", Role = PlayerRole.Sup, Buyingprice = 310, Sellingprice = 280, Imageurl = "gen_lehends.jpg" },

//// Dplus KIA (DK) - Korea
//new Player { Ign = "Kingen", IrlName = "Hwang Seong-hoon", Team = "Dplus KIA", Role = PlayerRole.Top, Buyingprice = 280, Sellingprice = 250, Imageurl = "dk_kingen.jpg" },
//new Player { Ign = "Lucid", IrlName = "Choi Yong-hyeok", Team = "Dplus KIA", Role = PlayerRole.JG, Buyingprice = 270, Sellingprice = 240, Imageurl = "dk_lucid.jpg" },
//new Player { Ign = "ShowMaker", IrlName = "Heo Su", Team = "Dplus KIA", Role = PlayerRole.Mid, Buyingprice = 360, Sellingprice = 330, Imageurl = "dk_showmaker.jpg" },
//new Player { Ign = "Aiming", IrlName = "Kim Ha-ram", Team = "Dplus KIA", Role = PlayerRole.Adc, Buyingprice = 290, Sellingprice = 260, Imageurl = "dk_aiming.jpg" },
//new Player { Ign = "Kellin", IrlName = "Kim Hyeong-gyu", Team = "Dplus KIA", Role = PlayerRole.Sup, Buyingprice = 260, Sellingprice = 230, Imageurl = "dk_kellin.jpg" },

//// Hanwha Life Esports (HLE) - Korea
//new Player { Ign = "Doran", IrlName = "Choi Hyeon-joon", Team = "Hanwha Life", Role = PlayerRole.Top, Buyingprice = 300, Sellingprice = 270, Imageurl = "hle_doran.jpg" },
//new Player { Ign = "Peanut", IrlName = "Han Wang-ho", Team = "Hanwha Life", Role = PlayerRole.JG, Buyingprice = 310, Sellingprice = 280, Imageurl = "hle_peanut.jpg" },
//new Player { Ign = "Zeka", IrlName = "Kim Geon-woo", Team = "Hanwha Life", Role = PlayerRole.Mid, Buyingprice = 320, Sellingprice = 290, Imageurl = "hle_zeka.jpg" },
//new Player { Ign = "Viper", IrlName = "Park Do-hyeon", Team = "Hanwha Life", Role = PlayerRole.Adc, Buyingprice = 350, Sellingprice = 320, Imageurl = "hle_viper.jpg" },
//new Player { Ign = "Delight", IrlName = "Yoo Hwan-joong", Team = "Hanwha Life", Role = PlayerRole.Sup, Buyingprice = 290, Sellingprice = 260, Imageurl = "hle_delight.jpg" },

//// KT Rolster - Korea
//new Player { Ign = "PerfecT", IrlName = "Park Myung-geun", Team = "KT Rolster", Role = PlayerRole.Top, Buyingprice = 250, Sellingprice = 220, Imageurl = "kt_perfect.jpg" },
//new Player { Ign = "Pyosik", IrlName = "Hong Chang-hyeon", Team = "KT Rolster", Role = PlayerRole.JG, Buyingprice = 280, Sellingprice = 250, Imageurl = "kt_pyosik.jpg" },
//new Player { Ign = "Bdd", IrlName = "Gwak Bo-seong", Team = "KT Rolster", Role = PlayerRole.Mid, Buyingprice = 310, Sellingprice = 280, Imageurl = "kt_bdd.jpg" },
//new Player { Ign = "Deft", IrlName = "Kim Hyuk-kyu", Team = "KT Rolster", Role = PlayerRole.Adc, Buyingprice = 320, Sellingprice = 290, Imageurl = "kt_deft.jpg" },
//new Player { Ign = "BeryL", IrlName = "Cho Geon-hee", Team = "KT Rolster", Role = PlayerRole.Sup, Buyingprice = 300, Sellingprice = 270, Imageurl = "kt_beryl.jpg" },

//// Kwangdong Freecs (KDF) - Korea
//new Player { Ign = "DuDu", IrlName = "Lee Dong-ju", Team = "KDF", Role = PlayerRole.Top, Buyingprice = 220, Sellingprice = 190, Imageurl = "kdf_dudu.jpg" },
//new Player { Ign = "Cuzz", IrlName = "Moon Woo-chan", Team = "KDF", Role = PlayerRole.JG, Buyingprice = 240, Sellingprice = 210, Imageurl = "kdf_cuzz.jpg" },
//new Player { Ign = "BuLLDoG", IrlName = "Lee Tae-young", Team = "KDF", Role = PlayerRole.Mid, Buyingprice = 230, Sellingprice = 200, Imageurl = "kdf_bulldog.jpg" },
//new Player { Ign = "Taeyoon", IrlName = "Kim Tae-yoon", Team = "KDF", Role = PlayerRole.Adc, Buyingprice = 210, Sellingprice = 180, Imageurl = "kdf_taeyoon.jpg" },
//new Player { Ign = "Andil", IrlName = "Lee Gwang-jun", Team = "KDF", Role = PlayerRole.Sup, Buyingprice = 200, Sellingprice = 170, Imageurl = "kdf_andil.jpg" },

//// BRION - Korea
//new Player { Ign = "Morgan", IrlName = "Park Gi-tae", Team = "BRION", Role = PlayerRole.Top, Buyingprice = 210, Sellingprice = 180, Imageurl = "bro_morgan.jpg" },
//new Player { Ign = "UmTi", IrlName = "Um Seong-hyeon", Team = "BRION", Role = PlayerRole.JG, Buyingprice = 230, Sellingprice = 200, Imageurl = "bro_umti.jpg" },
//new Player { Ign = "Karis", IrlName = "Kim Hong-jo", Team = "BRION", Role = PlayerRole.Mid, Buyingprice = 240, Sellingprice = 210, Imageurl = "bro_karis.jpg" },
//new Player { Ign = "Envyy", IrlName = "Lee Myeong-jun", Team = "BRION", Role = PlayerRole.Adc, Buyingprice = 220, Sellingprice = 190, Imageurl = "bro_envyy.jpg" },
//new Player { Ign = "Effort", IrlName = "Lee Sang-ho", Team = "BRION", Role = PlayerRole.Sup, Buyingprice = 230, Sellingprice = 200, Imageurl = "bro_effort.jpg" },

//// Nongshim RedForce (NS) - Korea
//new Player { Ign = "DnDn", IrlName = "Kim Seung-min", Team = "Nongshim", Role = PlayerRole.Top, Buyingprice = 200, Sellingprice = 170, Imageurl = "ns_dndn.jpg" },
//new Player { Ign = "Sylvie", IrlName = "Jeong Jin-hyeok", Team = "Nongshim", Role = PlayerRole.JG, Buyingprice = 210, Sellingprice = 180, Imageurl = "ns_sylvie.jpg" },
//new Player { Ign = "Callme", IrlName = "Park Jin-seong", Team = "Nongshim", Role = PlayerRole.Mid, Buyingprice = 220, Sellingprice = 190, Imageurl = "ns_callme.jpg" },
//new Player { Ign = "Jiwoo", IrlName = "Jeong Ji-woo", Team = "Nongshim", Role = PlayerRole.Adc, Buyingprice = 230, Sellingprice = 200, Imageurl = "ns_jiwoo.jpg" },
//new Player { Ign = "Peter", IrlName = "Park Yun-sung", Team = "Nongshim", Role = PlayerRole.Sup, Buyingprice = 210, Sellingprice = 180, Imageurl = "ns_peter.jpg" },

//// DRX - Korea (kisebb csapat, alacsonyabb árak)
//new Player { Ign = "Rascal", IrlName = "Kim Kwang-hee", Team = "DRX", Role = PlayerRole.Top, Buyingprice = 190, Sellingprice = 160, Imageurl = "drx_rascal.jpg" },
//new Player { Ign = "Sponge", IrlName = "Lee Seung-min", Team = "DRX", Role = PlayerRole.JG, Buyingprice = 180, Sellingprice = 150, Imageurl = "drx_sponge.jpg" },
//new Player { Ign = "SeTab", IrlName = "Jeong Jin-woo", Team = "DRX", Role = PlayerRole.Mid, Buyingprice = 200, Sellingprice = 170, Imageurl = "drx_setab.jpg" },
//new Player { Ign = "Teddy", IrlName = "Park Jin-seong", Team = "DRX", Role = PlayerRole.Adc, Buyingprice = 250, Sellingprice = 220, Imageurl = "drx_teddy.jpg" },
//new Player { Ign = "Pleata", IrlName = "Park Jin-woo", Team = "DRX", Role = PlayerRole.Sup, Buyingprice = 190, Sellingprice = 160, Imageurl = "drx_pleata.jpg" },
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

              //  await _db.InsertAllAsync(players);

               
           // }

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

        public Task<Player> GetPlayerByIgnAsync(string Ign)
        {
            return _db.Table<Player>()
                      .Where(i => i.Ign == Ign)
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
                   ?? new UserTeam { Budget = 1000 }; 
        }

        public async Task SaveUserTeamAsync(UserTeam userTeam)
        {
            await _db.InsertOrReplaceAsync(userTeam);
        }


        public async Task UpdateUserTeamAsync(UserTeam userteam)
        {
            await _db.UpdateAsync(userteam);
        }




        #endregion

    }
}
