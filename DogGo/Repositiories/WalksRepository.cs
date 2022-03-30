using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DogGo.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalksRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walk> GetAllWalks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT w.*, wr.Name as WalkerName, d.Name as DogName
                        FROM Walk w
                        JOIN Walker wr ON w.WalkerId = w.Id
                        JOIN Dog d ON w.DogId = d.Id
                    ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Walk> walks = new List<Walk>();
                        while (reader.Read())
                        {
                            Walk walk = new Walk
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                                WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                                DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                                Walker = new Walker
                                {
                                    Name = reader.GetString(reader.GetOrdinal("WalkerName"))
                                },
                                Dog = new Dog
                                {
                                    Name = reader.GetString(reader.GetOrdinal("DogName"))
                                }
                            };

                            walks.Add(walk);
                        }

                        return walks;
                    }
                }
            }
        }


        public List<Walk> GetWalksByWalkerId(int walkerId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
	                                        w.Id, 
	                                        w.[Date], 
	                                        w.Duration, 
	                                        o.[Name] as OwnerName, 
	                                        d.[Name] as DogName 
	                                    FROM Walks w 
	                                    LEFT JOIN Dog d on w.DogId = d.Id 
	                                    LEFT JOIN [Owner] o on d.OwnerId = o.Id 
	                                    WHERE w.WalkerId = @id;";
                    cmd.Parameters.AddWithValue("@id", walkerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Walk> walks = new List<Walk>();
                        while (reader.Read())
                        {
                            Walk walk = new Walk
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                                Owner = new Owner
                                {
                                    Name = reader.GetString(reader.GetOrdinal("OwnerName"))
                                },
                                Dog = new Dog
                                {
                                    Name = reader.GetString(reader.GetOrdinal("DogName"))
                                }

                            };
                            walks.Add(walk);
                        }
                        return walks;
                    }
                }
            }
        }

    }
}

