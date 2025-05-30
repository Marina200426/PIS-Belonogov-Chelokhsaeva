using System.Collections.Generic;
using System;

public class ApplicationRepository : IApplicationRepository
{
    private readonly DatabaseHelper dbHelper;

    public ApplicationRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public List<Applications> FindByUserId(int userId)
    {
        var applications = new List<Applications>();
        string query = @"
            SELECT a.id, a.user_id, a.service_id, s.name AS service_name, u.full_name AS user_name, s.requirements,
                   a.date_submitted, a.planned_date, a.status, a.result
            FROM application a
            JOIN services s ON a.service_id = s.id
            JOIN users u ON a.user_id = u.id
            WHERE a.user_id = @user_id";
        var parameters = new Dictionary<string, object> { { "user_id", userId } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                applications.Add(new Applications
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    ServiceId = reader.GetInt32(2),
                    ServiceName = reader.GetString(3),
                    UserName = reader.GetString(4),
                    Requirements = reader.IsDBNull(5) ? null : reader.GetString(5),
                    DateSubmitted = reader.GetDateTime(6),
                    PlannedDate = reader.GetDateTime(7),
                    Status = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), reader.GetString(8)),
                    Result = reader.IsDBNull(9) ? null : reader.GetString(9)
                });
            }
        }
        return applications;
    }

    public List<Applications> FindByResponsibleId(int responsibleId)
    {
        var applications = new List<Applications>();
        string query = @"
            SELECT a.id, a.user_id, a.service_id, s.name AS service_name, u.full_name AS user_name, s.requirements,
                   a.date_submitted, a.planned_date, a.status, a.result
            FROM application a
            JOIN services s ON a.service_id = s.id
            JOIN users u ON a.user_id = u.id
            WHERE s.responsible_id = @responsible_id";
        var parameters = new Dictionary<string, object> { { "responsible_id", responsibleId } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                applications.Add(new Applications
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    ServiceId = reader.GetInt32(2),
                    ServiceName = reader.GetString(3),
                    UserName = reader.GetString(4),
                    Requirements = reader.IsDBNull(5) ? null : reader.GetString(5),
                    DateSubmitted = reader.GetDateTime(6),
                    PlannedDate = reader.GetDateTime(7),
                    Status = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), reader.GetString(8)),
                    Result = reader.IsDBNull(9) ? null : reader.GetString(9)
                });
            }
        }
        return applications;
    }

    public void Create(Applications application)
    {
        string query = "INSERT INTO application (user_id, service_id, date_submitted, planned_date, status, result) VALUES (@user_id, @service_id, @date_submitted, @planned_date, @status, @result)";
        var parameters = new Dictionary<string, object>
        {
            { "user_id", application.UserId },
            { "service_id", application.ServiceId },
            { "date_submitted", application.DateSubmitted },
            { "planned_date", application.PlannedDate },
            { "status", application.Status.ToString() },
            { "result", (object)application.Result ?? DBNull.Value }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void Update(Applications application)
    {
        string query = "UPDATE application SET status = @status, result = @result WHERE id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "id", application.Id },
            { "status", application.Status.ToString() },
            { "result", (object)application.Result ?? DBNull.Value }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public Applications GetApplication(int applicationId)
    {
        string query = @"
            SELECT a.id, a.user_id, a.service_id, s.name AS service_name, u.full_name AS user_name, s.requirements,
                   a.date_submitted, a.planned_date, a.status, a.result
            FROM application a
            JOIN services s ON a.service_id = s.id
            JOIN users u ON a.user_id = u.id
            WHERE a.id = @id";
        var parameters = new Dictionary<string, object> { { "id", applicationId } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            if (reader.Read())
            {
                return new Applications
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    ServiceId = reader.GetInt32(2),
                    ServiceName = reader.GetString(3),
                    UserName = reader.GetString(4),
                    Requirements = reader.IsDBNull(5) ? null : reader.GetString(5),
                    DateSubmitted = reader.GetDateTime(6),
                    PlannedDate = reader.GetDateTime(7),
                    Status = (ApplicationStatus)Enum.Parse(typeof(ApplicationStatus), reader.GetString(8)),
                    Result = reader.IsDBNull(9) ? null : reader.GetString(9)
                };
            }
            return null;
        }
    }
}