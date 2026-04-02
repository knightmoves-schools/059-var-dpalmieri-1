namespace knightmoves;

public class ListUtility{

    public List<string> Copy(params string[] items){
        List<string> listItems = new List<string>();

        foreach(string item in items){
            listItems.Add(item);
        }
        
        return listItems;
    }
}