using Core_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_API.Repositories
{
    public class DepartmentRepository : IRepository<Department, int>
    {
        private readonly CompanyContext _context;

        /// <summary>
        /// Inject the CompanyContext
        /// </summary>
        /// <param name="context"></param>
        public DepartmentRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateAsync(Department entity)
        {
            try
            {
                var result = await _context.Departments.AddAsync(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var record = await _context.Departments.FindAsync(id);
                if (record != null)
                {
                    _context.Departments.Remove(record);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Department>> GetAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetAsync(int id)
        {
            return  await _context.Departments.FindAsync(id);
        }

        public async Task<Department> UpdateAsync(int id, Department entity)
        {
            try
            {
                var record = await _context.Departments.FindAsync(id);
                if (record == null) return null;

                //_context.Entry(entity).State = EntityState.Detached;
                //_context.Entry(entity).State = EntityState.Modified;

                record.DeptNo = entity.DeptNo;
                record.DeptName = entity.DeptName;
                record.Capacity = entity.Capacity;
                record.Location = entity.Location;


                // _context.Update<Department>(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
