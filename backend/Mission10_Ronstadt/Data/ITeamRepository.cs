namespace Mission10_Ronstadt.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Teams { get; }
    }
}
