using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10_Ronstadt.Data;

namespace Mission10_Ronstadt.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        private ITeamRepository _teamRepository;
        
        public BowlerController(IBowlerRepository bowlerRepository, ITeamRepository teamRepository)
        {
            _bowlerRepository = bowlerRepository;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var joinedData = from Bowler in _bowlerRepository.Bowlers
                             join Team in _teamRepository.Teams
                             on Bowler.TeamId equals Team.TeamId
                             select new
                             {
                                 BowlerId = Bowler.BowlerId,
                                 BowlerName = $"{Bowler.BowlerFirstName} {Bowler.BowlerMiddleInit} {Bowler.BowlerLastName}",
                                 TeamName = Team.TeamName,
                                 Address = Bowler.BowlerAddress,
                                 City = Bowler.BowlerCity,
                                 State = Bowler.BowlerState,
                                 Zip = Bowler.BowlerZip,
                                 PhoneNumber = Bowler.BowlerPhoneNumber,

                             };

            return joinedData.ToArray();
        }
    }
}
