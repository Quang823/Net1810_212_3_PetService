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
        Task<IBusinessResult> GetById(string code);
        Task<IBusinessResult> Save(Payment Payment);
        Task<IBusinessResult> Update(Payment Payment);
        Task<IBusinessResult> DeleteById(string code);
    }
    public class PaymentBusiness : IPaymentBusiness
    {
        //private readonly PaymentDAO _DAO;        
        //private readonly PaymentRepository _PaymentRepository;
        private readonly UnitOfWork _unitOfWork;

        public PaymentBusiness()
        {
            //_PaymentRepository ??= new PaymentRepository();            
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                #region Business rule
                #endregion

                //var payments = _DAO.GetAll();
                //var payments = await _PaymentRepository.GetAllAsync();
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

        public async Task<IBusinessResult> GetById(string code)
        {
            try
            {
                #region Business rule
                #endregion

                //var Payment = await _PaymentRepository.GetByIdAsync(code);
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
                //int result = await _PaymentRepository.CreateAsync(Payment);
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
                //int result = await _PaymentRepository.UpdateAsync(Payment);
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

        public async Task<IBusinessResult> DeleteById(string code)
        {
            try
            {
                //var Payment = await _PaymentRepository.GetByIdAsync(code);
                var Payment = await _unitOfWork.PaymentRepository.GetByIdAsync(code);
                if (Payment != null)
                {
                    //var result = await _PaymentRepository.RemoveAsync(Payment);
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
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.ToString());
            }
        }

    }
}