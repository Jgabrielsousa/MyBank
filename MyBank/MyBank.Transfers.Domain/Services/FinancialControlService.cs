using MyBank.Accounts.Domain.Dtos;
using MyBank.Infra.CrossCutting;
using MyBank.Shared.Domain.Services.Base;
using MyBank.Transfers.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBank.Transfers.Domain.Services
{
    public class FinancialControlService : ServiceBase<FinancialControl> , IFinancialControlService
    {
        private readonly IFinancialControlRepository _repoFC;

        public FinancialControlService(IFinancialControlRepository repoFC):base(repoFC)
        {
            _repoFC = repoFC;
        }

        public async Task<RequestResult> Credit(TransferDto transfer)
        {
            try
            {
                var toAccount = await GetAccount(transfer.ToAccountId);
                toAccount.Balance += transfer.Amount;
                await UpdateAccountQueue(toAccount.Id, toAccount.Balance);
                //NOTIFICA USUARIO DO CREDITATO
                _repoFC.Credit(toAccount.Balance, transfer.Amount, transfer.ToAccountId, transfer.FromAccountId);


                return new RequestResult() { Data = true, Mensagens = new List<string>() { "Credito realizado com sucesso" }, Status = StatusMensagem.Ok };
            }
            catch (Exception erro)
            {
                return new RequestResult() { Data = false, Mensagens = new List<string>() { $"Algo deu errado com a transferencia track => {erro}" }, Status = StatusMensagem.Ok };
            }

        }

        public async  Task<RequestResult> Debt(TransferDto transfer)
        {
            try
            {
                var fromAccount = await GetAccount(transfer.FromAccountId);
                if (fromAccount.Balance < transfer.Amount)
                    return new RequestResult() { Data = false, Mensagens = new List<string>() { "Saldo insuficiente para a transferencia" }, Status = StatusMensagem.Ok };

                fromAccount.Balance -= transfer.Amount;
                await UpdateAccountQueue(fromAccount.Id, fromAccount.Balance);
                //NOTIFICA USUARIO DO DEBITADO 
                _repoFC.Debt(fromAccount.Balance, transfer.Amount, transfer.FromAccountId, transfer.ToAccountId);
                return new RequestResult() { Data = true, Mensagens = new List<string>() { "Debito realizado com sucesso" }, Status = StatusMensagem.Ok };
            }
            catch (Exception)
            {
                return new RequestResult() { Data = false, Mensagens = new List<string>() { "Algo deu errado com a transferencia" }, Status = StatusMensagem.Ok };
            }

        }
        
        
        public IEnumerable<FinancialControl> GetByAccountId(int id)
        {
            return _repoFC.GetByAccountId(id);
        }

        private async Task<AccountDto> GetAccount(int accountId)
        {
            AccountDto account = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                  
                    HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/api/Accounts/{accountId}");

                    if (response.IsSuccessStatusCode)
                    {
                        await response.Content.ReadAsStringAsync().ContinueWith(x =>
                          {
                              var json = x.Result;
                              account = JsonConvert.DeserializeObject<AccountDto>(json);
                          });
                    }

                    return account;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> UpdateAccountQueue(int accountId, decimal amount)
        {
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync($"https://localhost:5001/api/Accounts/{accountId}/{amount}",null);
                    return response.IsSuccessStatusCode;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
