using System;
using System.Collections.Generic;
using System.Text;
using Mappers;
using DataLayer.UnitOfWork;
using BusinessLogic;
using System.Linq;
using Services.Abstract;
using System.Security.Cryptography;
using BusinessLogic.Model;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private DoctorMapper _doctorMapper;

        private ClientMapper _clientMapper;

        private AdminMapper _adminMapper;

        public UserService(IUnitOfWork unitOfWork, DoctorMapper doctorMapper, ClientMapper clientMapper)
        {
            _doctorMapper = doctorMapper;

            _clientMapper = clientMapper;

            _unitOfWork = unitOfWork;

            _adminMapper = new AdminMapper();
        }

        public Client GetClietnById(int id) 
        {
            return _clientMapper.FromEntityToDomain(_unitOfWork.ClientRepository.GetByID(id));
        }

        public Doctor GetDoctorById(int id) 
        {
            return _doctorMapper.FromEntityToDomain(_unitOfWork.DoctorRepository.GetByID(id));
        }

        public Administrator GetAdminByUserName(string username) 
        {
            return _adminMapper.FromEntityToDomain(_unitOfWork.ClientRepository.GetAdminByUserName(username));
        }

        public Client GetClientByUserName(string username) 
        {
            if (_unitOfWork.ClientRepository.GetClientByUsername(username) != null)
            {
                return _clientMapper.FromEntityToDomain(_unitOfWork.ClientRepository.GetClientByUsername(username));
            }
            else 
            {
                return null;
            }
            
            
        }

        public Doctor GetDoctorByUserName(string username) 
        {


            if (_unitOfWork.DoctorRepository.GetDoctorByUsername(username) != null)
            {
                return _doctorMapper.FromEntityToDomain(_unitOfWork.DoctorRepository.GetDoctorByUsername(username));
            }
            else 
            {
                return null;
            }
        }

        public void AddClient(string username, string phone, string email, string passwordHash, string clientName, int cityId) 
        {
            Client newCLient = new Client(_unitOfWork.ClientRepository.NextID(), clientName, phone, email, cityId, passwordHash, username);
            if (GetClientByUserName(username)==null) 
            {
                _unitOfWork.ClientRepository.Add(_clientMapper.NewExample(newCLient));
            }
        }

        public void AddDoctor(string username, string passwordHash, string clientName)
        {
            if (GetDoctorByUserName(username) == null) 
            {
                _unitOfWork.DoctorRepository.Add(_doctorMapper.NewExample(new Doctor(_unitOfWork.DoctorRepository.NextID(), clientName, passwordHash, username)));
            }
        }

        public List<Client> GetAllClients() 
        {
            return _unitOfWork.ClientRepository.GetAll().Select(cl => _clientMapper.FromEntityToDomain(cl)).ToList();
        }

        public void RemoveClient(int ID) 
        {
            _unitOfWork.ClientRepository.Delete(ID);

        }

        public void RemoveDoctor(int ID) 
        {
            _unitOfWork.DoctorRepository.Delete(ID);
        }

        public void UpdateClient(Client client) 
        {
            _unitOfWork.ClientRepository.Update(_clientMapper.FromDomainToEntity(client));
        }

        public void UpdateDoctor(Doctor doctor) 
        {
            _unitOfWork.DoctorRepository.Update(_doctorMapper.FromDomainToEntity(doctor));
        }

        public string GetHash(string word) 
        {
            return GetHashString(word);
        }

        public static byte[] GetHashOfAString(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHashOfAString(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public List<Doctor> GetAllDoctors() 
        {
            return _unitOfWork.DoctorRepository.GetAll().Select(dc => _doctorMapper.FromEntityToDomain(dc)).ToList();
        }

    }
}
