using Model.Entities.Authentication;

namespace Model.Entities.Log;

[Table("LOGINS")]
public class Login
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [Column("USER_ID")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    public ELoginStatus LoginStatus { get; set; }
    
    public DateTime DateTime { get; set; }
}

public enum ELoginStatus
{
    SUCCESS,
    WRONG_PASSWORD,
    FAILED
}