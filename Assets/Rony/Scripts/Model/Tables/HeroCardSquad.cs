using SQLite;


[Table("herocardsquads")]
public class HeroCardSquadRecord
{
    [PrimaryKey, AutoIncrement]
    public int squadId { get; set; }
    public int cardId { get; set; }
}