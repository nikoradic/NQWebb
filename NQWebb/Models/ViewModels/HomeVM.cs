namespace NQWebb.Models.ViewModels;

public class HomeVM
{

    public List<CollectionVM> Collection { get; set; } = new();
    public CollectionVM? BestCollection { get; set; }
    public CollectionVM? New { get; set; }
}
