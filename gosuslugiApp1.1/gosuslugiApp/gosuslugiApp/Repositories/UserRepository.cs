using System.Collections.Generic;
using System;

public class UserRepository : IUserRepository
{
    private readonly DatabaseHelper dbHelper;

    public UserRepository(DatabaseHelper dbHelper)
    {
        this.dbHelper = dbHelper;
    }

    public User FindById(int id)
    {
        string query = "SELECT id, full_name, email, password, role FROM users WHERE id = @id";
        var parameters = new Dictionary<string, object> { { "id", id } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(4))
                };
            }
            return null;
        }
    }

    public User FindByEmail(string email)
    {
        string query = "SELECT id, full_name, email, password, role FROM users WHERE email = @email";
        var parameters = new Dictionary<string, object> { { "email", email } };
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(4))
                };
            }
            return null;
        }
    }
    public List<User> GetAll()
    {
        var types = new List<User>();
        string query = "SELECT id, full_name, email, password, role FROM users";
        var parameters = new Dictionary<string, object>();
        using (var reader = dbHelper.ExecuteQuery(query, parameters))
        {
            while (reader.Read())
            {
                types.Add(new User
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),
                    Role = (UserRole)Enum.Parse(typeof(UserRole), reader.GetString(4))
                });
            }
        }
        return types;
    }

    public void CreateUser(User user)
    {
        string query = "INSERT INTO users (full_name, email, password, role) VALUES (@full_name, @email, @password, @role)";
        var parameters = new Dictionary<string, object>
        {
            { "full_name", user.FullName },
            { "email", user.Email },
            { "password", user.Password },
            { "role", user.Role.ToString() }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }

    public void UpdateUser(User user)
    {
        string query = "UPDATE users SET full_name = @full_name, email = @email, password = @password, role = @role WHERE id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "id", user.Id },
            { "full_name", user.FullName },
            { "email", user.Email },
            { "password", user.Password },
            { "role", user.Role.ToString() }
        };
        dbHelper.ExecuteNonQuery(query, parameters);
    }
}