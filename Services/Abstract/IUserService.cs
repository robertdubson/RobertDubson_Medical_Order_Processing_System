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

        public void AddDoctor(string username, string passwordHash, string clientName);

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

    }
}
