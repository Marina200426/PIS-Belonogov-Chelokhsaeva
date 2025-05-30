using System.Collections.Generic;
using System;

public class ServiceRepository : IServiceRepository
{
    private readonly DatabaseHelper dbHelper;

    public ServiceRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public List<Service> GetActiveServices()
    {
        var services = new List<Service>();
        string query = "SELECT id, name, requirements, date_activated, date_deactivated, responsible_id FROM services WHERE date_activated <= @today AND (date_deactivated IS NULL OR date_deactivated > @today)";
        var parameters = new Dictionary<string, object> { { "today", DateTime.Now } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                services.Add(new Service
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Requirements = reader.IsDBNull(2) ? null : reader.GetString(2),
                    DateActivated = reader.GetDateTime(3),
                    DateDeactivated = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                    ResponsibleId = reader.GetInt32(5)
                });
            }
        }
        return services;
    }

    public Service FindById(int id)
    {
        string query = "SELECT id, name, requirements, date_activated, date_deactivated, responsible_id FROM services WHERE id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            if (reader.Read())
            {
                return new Service
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Requirements = reader.IsDBNull(2) ? null : reader.GetString(2),
                    DateActivated = reader.GetDateTime(3),
                    DateDeactivated = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                    ResponsibleId = reader.GetInt32(5)
                };
            }
            return null;
        }
    }

    public void Create(Service service)
    {
        string query = "INSERT INTO services (name, requirements, date_activated, date_deactivated, responsible_id) VALUES (@name, @requirements, @date_activated, @date_deactivated, @responsible_id)";
        var parameters = new Dictionary<string, object>
        {
            { "name", service.Name },
            { "requirements", (object)service.Requirements ?? DBNull.Value },
            { "date_activated", service.DateActivated },
            { "date_deactivated", (object)service.DateDeactivated ?? DBNull.Value },
            { "responsible_id", service.ResponsibleId }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Update(Service service)
    {
        string query = "UPDATE services SET name = @name, requirements = @requirements, date_activated = @date_activated, date_deactivated = @date_deactivated, responsible_id = @responsible_id WHERE id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "id", service.Id },
            { "name", service.Name },
            { "requirements", (object)service.Requirements ?? DBNull.Value },
            { "date_activated", service.DateActivated },
            { "date_deactivated", (object)service.DateDeactivated ?? DBNull.Value },
            { "responsible_id", service.ResponsibleId }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Deactivate(int serviceId)
    {
        string query = "UPDATE services SET date_deactivated = @date_deactivated WHERE id = @id AND date_deactivated IS NULL";
        var parameters = new Dictionary<string, object>
        {
            { "id", serviceId },
            { "date_deactivated", DateTime.Now }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }
}
