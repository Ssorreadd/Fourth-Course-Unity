using System.Linq;

public class Player
{
    public LeaderType Info { get; set; }

    private Player()
    {
        Info = new LeaderType()
        {
            Id = GetUniqueId()
        };
    }

    private static Player _context;

    public static Player GetContext()
    {
        if (_context == null)
        {
            _context = new Player();
        }

        return _context;
    }

    private int GetUniqueId()
    {
        var list = LeadersBase.GetContext().Leaders.OrderByDescending(x => x.Id).ToList();

        return list.Count == 0 ? 0 : list[0].Id++; 
    }
}
