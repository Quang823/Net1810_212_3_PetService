using PetService.Business.Base;
using PetService.Common;
using PetService.Data;
using PetService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetService.Business
{
    public interface IPaymentBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int code);
        Task<IBusinessResult> Save(Payment Payment);
        Task<IBusinessResult> Update(Payment Payment);
        Task<IBusinessResult> DeleteById(int code);
    }
    public class PaymentBusiness : IPaymentBusiness
    {
        //private readonly PetDAO _DAO;        
        //private readonly PetRepository _PetRepository;
        private readonly UnitOfWork _unitOfWork;

        public PaymentBusiness()
        {
            //_PetRepository ??= new PetRepository();            
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                //var pets = _DAO.GetAll();
                //var pets = await _PetRepository.GetAllAsync();
                var payments = await _unitOfWork.PaymentRepository.GetAllAsync();


                if (payments == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, payments);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(int code)
        {
            try
            {
                #region Business rule
                #endregion

                //var Pet = await _PetRepository.GetByIdAsync(code);
                var Payment = await _unitOfWork.PaymentRepository.GetByIdAsync(code);

                if (Payment == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, Payment);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(Payment Payment)
        {
            try
            {
                //int result = await _PetRepository.CreateAsync(Pet);
                int result = await _unitOfWork.PaymentRepository.CreateAsync(Payment);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(Payment Payment)
        {
            try
            {
                //int result = await _PetRepository.UpdateAsync(Pet);
                int result = await _unitOfWork.PaymentRepository.UpdateAsync(Payment);

                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteById(int code)
        {
            try
            {
                //var Pet = await _PetRepository.GetByIdAsync(code);
                var Payment = await _unitOfWork.PaymentRepository.GetByIdAsync(code);
                if (Payment != null)
                {
                    //var result = await _PetRepository.RemoveAsync(Pet);
                    var result = await _unitOfWork.PaymentRepository.RemoveAsync(Payment);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

    }
}

