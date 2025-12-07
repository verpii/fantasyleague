using fantasyleague.M;

namespace fantasyleague.DB
{
    public interface IDbService
    {
        Task<int> DeletePlayerAsync(Player player);
        Task<List<Player>> GetAllPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task<Player> GetPlayerByIgnAsync(string Ign);
        Task<List<Player>> GetPlayerByPriceAsync(int minprice, int maxprice);
        Task<List<Player>> GetPlayersByRoleAsync(PlayerRole role);
        Task<UserTeam> GetUserTeamAsync();
        Task<int> SavePlayerAsync(Player player);
        Task SaveUserTeamAsync(UserTeam userTeam);

        Task UpdateUserTeamAsync(UserTeam userTeam);
    }
}