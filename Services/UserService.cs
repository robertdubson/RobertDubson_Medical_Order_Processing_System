using System;
using System.Collections.Generic;
using System.Text;
using Mappers;
using DataLayer.UnitOfWork;
using BusinessLogic;
using System.Linq;
namespace Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private DoctorMapper _doctorMapper;

        private ClientMapper _clientMapper;

        public UserService(IUnitOfWork unitOfWork, DoctorMapper doctorMapper, ClientMapper clientMapper)
        {
            _doctorMapper = doctorMapper;

            _clientMapper = clientMapper;

            _unitOfWork = unitOfWork;
        }

        public Client GetClientByUserName(string username) 
        {
            return _clientMapper.FromEntityToDomain(_unitOfWork.ClientRepository.GetClientByUsername(username));
        }

        public Doctor GetDoctorByUserName(string username) 
        {
            return _doctorMapper.FromEntityToDomain(_unitOfWork.DoctorRepository.GetDoctorByUsername(username));
        }

        public void AddClient(string username, string passwordHash, string clientName, int cityId) 
        {
            if (GetClientByUserName(username)!=null) 
            {
                _unitOfWork.ClientRepository.Add(_clientMapper.FromDomainToEntity(new Client(_unitOfWork.ClientRepository.NextID(), clientName, cityId, passwordHash, username)));
            }
        }

        public void AddDoctor(string username, string passwordHash, string clientName)
        {
            if (GetDoctorByUserName(username) != null) 
            {
                _unitOfWork.DoctorRepository.Add(_doctorMapper.FromDomainToEntity(new Doctor(_unitOfWork.DoctorRepository.NextID(), clientName, passwordHash, username)));
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

        public void UpdateClient(Client client) 
        {
            _unitOfWork.ClientRepository.Update(_clientMapper.FromDomainToEntity(client));
        }


    }
}
