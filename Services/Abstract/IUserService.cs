using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using BusinessLogic.Model;
namespace Services.Abstract
{
    public interface IUserService
    {
        public Client GetClientByUserName(string username);

        public Doctor GetDoctorByUserName(string username);

        public void AddClient(string username, string phone, string email, string passwordHash, string clientName, int cityId);

        public void AddDoctor(string username, string passwordHash, string clientName, int locationId, string phone, string email);

        public List<Client> GetAllClients();

        public void RemoveClient(int ID);

        public void UpdateClient(Client client);
        public void UpdateDoctor(Doctor doctor);

        public string GetHash(string word);

        public Client GetClietnById(int id);
        public Doctor GetDoctorById(int id);

        public List<Doctor> GetAllDoctors();

        public void RemoveDoctor(int ID);

        public Administrator GetAdminByUserName(string username);

        public void AddAministrator(string pasHash, string username, string fullname, int locationId, string phone, string mail);

        public void DeleteAdmin(int Id);

        public List<Administrator> GetAllAdministrators();

        public void UpdateAdmin(Administrator admin);

        public Administrator GetAdminById(int Id);

    }
}
