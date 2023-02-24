

[System.Serializable]
public class CoffeeData
{
    public bool[] isItBuilding;
    public bool[] isArenda;

    public string nameOfBuisness;
    public string typeOfStyle;

    public float profit;
    public float expenses;
    public float fame;

    public int logo;

    //expences
        //итерированы аналогично дочерним скриптам
    public float[] rawExpences;
    public float[] rawCounts;
    public float[] workersExpencives;
    public float[] serviceExpencies;

    //profit
    public float[] productProfit;
    public float[] productCounts;


    public CoffeeData(Coffee coffee)
    {
        isArenda = coffee.isArenda;

        nameOfBuisness = coffee.nameOfBuisness;
        typeOfStyle = coffee.typeOfStyle;

        profit = coffee.profit;
        expenses = coffee.expenses;
        fame = coffee.fame;

        logo = coffee.logo;

        //expences
        rawExpences = coffee.rawExpences;
        rawCounts = coffee.rawCounts;
        serviceExpencies = coffee.serviceExpencies;
        workersExpencives = coffee.workersExpencives;
        //profit
        productProfit = coffee.productProfit;
        productCounts = coffee.productCounts;

}
}
