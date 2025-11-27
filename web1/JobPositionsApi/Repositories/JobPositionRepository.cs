using Dapper;
using JobPositionsApi.Models;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPositionsApi.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        private readonly string _connectionString;
        public JobPositionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private MySqlConnection GetConnection() => new MySqlConnection(_connectionString);

        public async Task<IEnumerable<JobPosition>> GetAllAsync()
        {
            using var conn = GetConnection();
            var sql = "SELECT id, name, beginning_salary AS BeginningSalary FROM JobPositions;";
            return await conn.QueryAsync<JobPosition>(sql);
        }

        public async Task<JobPosition> GetByIdAsync(int id)
        {
            using var conn = GetConnection();
            var sql = "SELECT id, name, beginning_salary AS BeginningSalary FROM JobPositions WHERE id = @Id;";
            return await conn.QueryFirstOrDefaultAsync<JobPosition>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(JobPosition job)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO JobPositions (name, beginning_salary) VALUES (@Name, @BeginningSalary);
                        SELECT LAST_INSERT_ID();";
            var newId = await conn.ExecuteScalarAsync<int>(sql, job);
            return newId;
        }

        public async Task<bool> UpdateAsync(JobPosition job)
        {
            using var conn = GetConnection();
            var sql = @"UPDATE JobPositions SET name = @Name, beginning_salary = @BeginningSalary WHERE id = @Id;";
            var affected = await conn.ExecuteAsync(sql, job);
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = GetConnection();
            var sql = "DELETE FROM JobPositions WHERE id = @Id;";
            var affected = await conn.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}
