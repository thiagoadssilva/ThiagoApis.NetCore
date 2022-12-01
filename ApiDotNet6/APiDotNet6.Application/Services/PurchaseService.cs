using ApiDotNet6.Domain.Entities;
using ApiDotNet6.Domain.Repositories;
using APiDotNet6.Application.DTOs;
using APiDotNet6.Application.DTOs.Validations;
using APiDotNet6.Application.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null) 
            {
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");
            }

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
            {
                return ResultService.RequestError<PurchaseDTO>("Problemas na validação", validate);
            }

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }

        public async Task<ResultService<ICollection<PurchateDetailDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchateDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchateDetailDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
            {
                return ResultService.Fail<PurchateDetailDTO>("Compra não localizada");
            }
            return ResultService.Ok(_mapper.Map<PurchateDetailDTO>(purchase));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if(purchase == null)
            {
                return ResultService.Fail($"Compra com o id: {id} não foi encontrado!");
            }
            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.Ok($"Compra do id: {id} foi removida com sucesso!");
        }

        public async Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
            {
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");
            }

            var result = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", result);
            }

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);
            if (purchase == null)
            {
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");
            }

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            purchase.Edit(purchase.Id, productId, personId);
            await _purchaseRepository.EditAsync(purchase);
            return ResultService.Ok(purchaseDTO);
        }
    }
}
