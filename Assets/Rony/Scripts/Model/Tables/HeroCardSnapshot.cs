using SQLite;

[Table("herocardsnapshots")]
public class HeroCardSnapshot
{
    [PrimaryKey, AutoIncrement]
    public int cardId { get; set; }
    public int count { get; set; }
    public int level { get; set; }
}