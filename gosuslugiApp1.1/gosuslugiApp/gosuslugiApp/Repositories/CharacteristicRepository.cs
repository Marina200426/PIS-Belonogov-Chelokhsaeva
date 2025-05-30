using System.Collections.Generic;

public class CharacteristicRepository : ICharacteristicRepository
{
    private readonly DatabaseHelper dbHelper;

    public CharacteristicRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public List<Characteristic> FindByUserId(int userId)
    {
        var characteristics = new List<Characteristic>();
        string query = @"
            SELECT c.id, c.user_id, c.type_id, ct.name AS type_name, c.value
            FROM characteristics c
            JOIN characteristic_types ct ON c.type_id = ct.id
            WHERE c.user_id = @user_id";
        var parameters = new Dictionary<string, object> { { "user_id", userId } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                characteristics.Add(new Characteristic
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    TypeId = reader.GetInt32(2),
                    TypeName = reader.GetString(3),
                    Value = reader.GetString(4)
                });
            }
        }
        return characteristics;
    }

    public void Create(Characteristic characteristic)
    {
        string query = "INSERT INTO characteristics (user_id, type_id, value) VALUES (@user_id, @type_id, @value)";
        var parameters = new Dictionary<string, object>
        {
            { "user_id", characteristic.UserId },
            { "type_id", characteristic.TypeId },
            { "value", characteristic.Value }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Delete(int id)
    {
        string query = "DELETE FROM characteristics WHERE id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Update(Characteristic characteristic)
    {
        string query = "UPDATE characteristics SET value = @value WHERE id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "id", characteristic.Id },
            { "value", characteristic.Value }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }
}