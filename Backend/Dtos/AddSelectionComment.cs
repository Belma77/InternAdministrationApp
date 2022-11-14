namespace Backend.Dtos
{
    public class AddSelectionComment
    {
        public int SelectionId { get; set; }
        public string Comment { get; set; }=String.Empty;   
    }
}
