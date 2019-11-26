using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// 
/// </summary>
public class SaveManager : Singleton<SaveManager>
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject blockPiecePrefab;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();
    
    /// <summary>
    /// 
    /// </summary>
    public void SaveProgress()
    {
        /*Debug.Log("Saved");*/
        Save save = SaveManager.Instance.CreateCheckpoint();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        if (SaveManager.Instance.IsTherePlayerData())
        {
            SaveManager.Instance.UpdatePlayerData();
        }
        else
        {
            SaveManager.Instance.CreatePlayerData();
        }
        
        SaveManager.Instance.binaryFormatter.Serialize(file, save);
        file.Close();
    }


    /// <summary>
    /// 
    /// </summary>
    public void LoadProgress()
    {
        /*Debug.Log("Loaded");*/
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
        Save save = (Save) SaveManager.Instance.binaryFormatter.Deserialize(file);
        SaveManager.Instance.LoadCheckpoint(save);
        file.Close();
        File.Delete(Application.persistentDataPath + "/save.dat");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsThereSave()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsTherePlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdatePlayerData()
    {
        FileStream playerDataFile = File.Open(Application.persistentDataPath + "/playerData.dat",FileMode.Open);
        PlayerData playerData = (PlayerData) SaveManager.Instance.binaryFormatter.Deserialize(playerDataFile);
        if (ScoreManager.Instance.HighScore > playerData.HighScore)
        {
            playerData.HighScore = ScoreManager.Instance.HighScore;
        }
        SaveManager.Instance.binaryFormatter.Serialize(playerDataFile,playerData);
        playerDataFile.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    public void LoadPlayerData()
    {
        FileStream playerDataFile = File.Open(Application.persistentDataPath + "/playerData.dat",FileMode.Open);
        PlayerData playerData = (PlayerData) SaveManager.Instance.binaryFormatter.Deserialize(playerDataFile);
        ScoreManager.Instance.HighScore = playerData.HighScore;
        playerDataFile.Close();
        File.Delete(Application.persistentDataPath +"/playerData.dat");
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void CreatePlayerData()
    {
        PlayerData playerData = new PlayerData();
        FileStream playerDataFile = File.Create(Application.persistentDataPath + "/playerData.dat");
        playerData.HighScore = ScoreManager.Instance.HighScore;
        SaveManager.Instance.binaryFormatter.Serialize(playerDataFile,playerData);
        playerDataFile.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Save CreateCheckpoint()
    {
        Save save = new Save();

        for (int row = 0; row < BoardManager.Instance.CurrentBoard.RowCount; row++)
        {
            for (int column = 0; column < BoardManager.Instance.CurrentBoard.ColumnCount; column++)
            {
                Tile_Save tileSave = new Tile_Save();
                tileSave.Status = BoardManager.Instance.CurrentBoard.Tiles[row, column].IsEmpty;
                save.Tiles[row, column] = tileSave;
            }
        }

        foreach (Slot slot in SlotManager.Instance.Slots)
        {
            Slot_Save slot_save = new Slot_Save {Id = slot.Id};
            save.Slots.Add(slot_save);
            if (!slot.IsEmpty)
            {
                Block block = slot.transform.GetChild(0).GetComponent<Block>();
                slot_save.Block = block.BlockType;
                slot_save.IsEmpty = false;
            }
            else
            {
                slot_save.IsEmpty = true;
            }
        }

        save.CurrentScore = ScoreManager.Instance.CurrentScore;
        
        return save;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="save"></param>
    private void LoadCheckpoint(Save save)
    {
        for (int row = 0; row < BoardManager.Instance.CurrentBoard.RowCount; row++)
        {
            for (int column = 0; column < BoardManager.Instance.CurrentBoard.ColumnCount; column++)
            {
                BoardManager.Instance.CurrentBoard.Tiles[row, column].IsEmpty = save.Tiles[row, column].Status;
                if (!BoardManager.Instance.CurrentBoard.Tiles[row, column].IsEmpty)
                {
                    GameObject blockPiece = Instantiate(SaveManager.Instance.blockPiecePrefab, BoardManager.Instance.CurrentBoard.Tiles[row, column].transform);
                }
            }
        }

        foreach (Slot_Save saveSlot in save.Slots)
        {
            if (!saveSlot.IsEmpty)
            {
                SlotManager.Instance.SpawnBlockAtSlot(saveSlot.Id-1 , saveSlot.Block);
            }
            else
            {
                SlotManager.Instance.Slots[saveSlot.Id-1].IsEmpty = true;
            }
        }

        ScoreManager.Instance.CurrentScore = save.CurrentScore;
    }
}
