public interface ICanBeSlowedItem
{
    public bool IsSlowed { get; set; }
    public void OnEnterIntoSlowedArea(float slowfactor);
}

