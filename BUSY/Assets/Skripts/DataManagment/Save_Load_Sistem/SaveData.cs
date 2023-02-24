
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    #region CompanyData
    public static void SaveCompanyData(Company company)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/companyData.log";
        FileStream stream = new FileStream(path, FileMode.Create);

        CompanyData data = new CompanyData(company);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CompanyData LoadCompanyData()
    {
        string path = Application.persistentDataPath + "/companyData.log";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CompanyData data = formatter.Deserialize(stream) as CompanyData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }

    }

    public static CompanyData DestroyCompanyData()
    {
        string path = Application.persistentDataPath + "/companyData.log";
        if (File.Exists(path))
        {
            File.Delete(path);
            return null;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }
    }
    #endregion

    #region Coffee Data
    public static void SaveCoffeeData(Coffee coffee)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/coffeeData.log";
        FileStream stream = new FileStream(path, FileMode.Create);

        CoffeeData data = new CoffeeData(coffee);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoffeeData LoadCoffeeData()
    {
        string path = Application.persistentDataPath + "/coffeeData.log";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoffeeData data = formatter.Deserialize(stream) as CoffeeData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }

    }

    public static CoffeeData DestroyCoffeeData()
    {
        string path = Application.persistentDataPath + "/coffeeData.log";
        if (File.Exists(path))
        {
            File.Delete(path);
            return null;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }
    }
    #endregion

    #region Coffee Bot Data
    public static void SaveCoffeeBotData(CoffeeBot coffee)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/coffeeBotData.log";
        FileStream stream = new FileStream(path, FileMode.Create);

        CoffeeBotData data = new CoffeeBotData(coffee);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoffeeBotData LoadCoffeeBotData()
    {
        string path = Application.persistentDataPath + "/coffeeBotData.log";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoffeeBotData data = formatter.Deserialize(stream) as CoffeeBotData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }

    }

    public static CoffeeBotData DestroyCoffeeBotData()
    {
        string path = Application.persistentDataPath + "/coffeeBotData.log";
        if (File.Exists(path))
        {
            File.Delete(path);
            return null;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }
    }
    #endregion

    #region Coffee Buildings Data
    public static void SaveCoffeeBuildData(CoffeeBuilding coffee)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/coffeeBuildData" + coffee.idOfBuild +".log";
        FileStream stream = new FileStream(path, FileMode.Create);

        CoffeeBuildsData data = new CoffeeBuildsData(coffee);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoffeeBuildsData LoadCoffeBuildData(int i)
    {
        string path = Application.persistentDataPath + "/coffeeBuildData" + i + ".log";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CoffeeBuildsData data = formatter.Deserialize(stream) as CoffeeBuildsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }

    }

    public static CoffeeBotData DestroyCoffeeBuildData()
    {
        string path = Application.persistentDataPath + "/coffeeBuildData.log";
        if (File.Exists(path))
        {
            File.Delete(path);
            return null;
        }
        else
        {
            Debug.LogError("" + path);
            return null;
        }
    }
    #endregion
}
