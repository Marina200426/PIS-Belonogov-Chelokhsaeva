using System.Collections.Generic;

public class CharacteristicTypeRepository : ICharacteristicTypeRepository
{
    private readonly DatabaseHelper dbHelper;

    public CharacteristicTypeRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public List<CharacteristicType> GetAll()
    {
        var types = new List<CharacteristicType>();
        string query = "SELECT id, name, value_type FROM characteristic_types";
        var parameters = new Dictionary<string, object>();
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                types.Add(new CharacteristicType
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    ValueType = reader.GetString(2)
                });
            }
        }
        return types;
    }

    public void Create(CharacteristicType type)
    {
        string query = "INSERT INTO characteristic_types (name, value_type) VALUES (@name, @value_type)";
        var parameters = new Dictionary<string, object>
        {
            { "name", type.Name },
            { "value_type", type.ValueType }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Delete(int id)
    {
        string query = "DELETE FROM characteristic_types WHERE id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

}