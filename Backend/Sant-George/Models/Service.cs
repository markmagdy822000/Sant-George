namespace SantGeorgeWebsite.Models
{
    public class Service
    {
        public int Id { get; set; }
        public ServiceType ServiceType { get; set; }
    }
    public enum ServiceType
    {
        BabyClass, Primary, Preparatory, Secondary, Youth, Graduates, General, 
        Bagom,Puppet_Theater, Service, Bible_Marathon
    }
}
