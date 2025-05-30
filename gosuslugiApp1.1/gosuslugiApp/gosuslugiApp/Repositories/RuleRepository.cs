using System.Collections.Generic;

public class RuleRepository : IRuleRepository
{
    private readonly DatabaseHelper dbHelper;

    public RuleRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public List<Rule> FindByServiceId(int serviceId)
    {
        var rules = new List<Rule>();
        string query = @"
            SELECT r.id, r.service_id, r.characteristic_type_id, ct.name AS characteristic_type_name,
                   r.name, r.value, r.deadline, r.operator
            FROM rules r
            JOIN characteristic_types ct ON r.characteristic_type_id = ct.id
            WHERE r.service_id = @service_id";
        var parameters = new Dictionary<string, object> { { "service_id", serviceId } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                rules.Add(new Rule
                {
                    Id = reader.GetInt32(0),
                    ServiceId = reader.GetInt32(1),
                    CharacteristicTypeId = reader.GetInt32(2),
                    CharacteristicTypeName = reader.GetString(3),
                    Name = reader.GetString(4),
                    Value = reader.GetString(5),
                    Deadline = reader.GetInt32(6),
                    Operator = reader.GetString(7)
                });
            }
        }
        return rules;
    }

    public void Create(Rule rule)
    {
        string query = "INSERT INTO rules (service_id, characteristic_type_id, name, value, deadline, operator) VALUES (@service_id, @characteristic_type_id, @name, @value, @deadline, @operator)";
        var parameters = new Dictionary<string, object>
        {
            { "service_id", rule.ServiceId },
            { "characteristic_type_id", rule.CharacteristicTypeId },
            { "name", rule.Name },
            { "value", rule.Value },
            { "deadline", rule.Deadline },
            { "operator", rule.Operator }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }
}
