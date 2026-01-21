using SQLite;


// please refer to the sqlite database to have the look at the current state of the database and to debug as well
[Table("herocardrecords")]
public class HeroCardRecord // this is the discussed hero card collection
{
    [PrimaryKey, AutoIncrement]
    public int cardId { get; set; }
    public int count { get; set; }
    public int level { get; set; }
}