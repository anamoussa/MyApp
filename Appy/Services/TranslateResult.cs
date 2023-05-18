namespace Appy.Services;


public class Available_languages
{
    public string it { get; set; }
    public string en { get; set; }

}
public class TranslateResult
{
    public string username { get; set; }
    public string password { get; set; }
    public string login { get; set; }
    public string email { get; set; }
    public string search { get; set; }
    public string scan { get; set; }
    public string cancel { get; set; }
    public Available_languages available_languages { get; set; }

}
