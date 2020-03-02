using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Infra.CrossCutting;
using MyBank.Shared.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Domain.Services
{
    public class FinancialControlService : IFinancialControlService
    {
        private readonly IFinancialControlRepository _repoFC;
        private readonly IAccountRepository _repoAcc;

        public FinancialControlService(IFinancialControlRepository repoFC, IAccountRepository repoAcc)
        {
            _repoFC = repoFC;
            _repoAcc = repoAcc;
        }

        public RequestResult Credit(TransferDto transfer)
        {
            try
            {
                var toAccount = _repoAcc.Find(transfer.ToAccountId);
                toAccount.Balance += transfer.Amount;
                _repoAcc.Update(toAccount);
                //NOTIFICA USUARIO DO CREDITATO
                _repoFC.Credit(toAccount.Balance, transfer.Amount, transfer.ToAccountId, transfer.FromAccountId);


                return new RequestResult() { Data = true, Mensagens = new List<string>() { "Credito realizado com sucesso" }, Status = StatusMensagem.Ok };
            }
            catch (Exception erro)
            {
                return new RequestResult() { Data = false, Mensagens = new List<string>() { $"Algo deu errado com a transferencia track => {erro}" }, Status = StatusMensagem.Ok };
            }

        }

        public RequestResult Debt(TransferDto transfer)
        {
            try
            {
                var fromAccount = _repoAcc.Find(transfer.FromAccountId);
                if (fromAccount.Balance < transfer.Amount)
                    return new RequestResult() { Data = false, Mensagens = new List<string>() { "Saldo insuficiente para a transferencia" }, Status = StatusMensagem.Ok };

                fromAccount.Balance -= transfer.Amount;
                _repoAcc.Update(fromAccount);
                //NOTIFICA USUARIO DO DEBITADO 
                _repoFC.Debt(fromAccount.Balance, transfer.Amount, transfer.FromAccountId, transfer.ToAccountId);
                return new RequestResult() { Data = true, Mensagens = new List<string>() { "Debito realizado com sucesso" }, Status = StatusMensagem.Ok };
            }
            catch (Exception)
            {
                return new RequestResult() { Data = false, Mensagens = new List<string>() { "Algo deu errado com a transferencia" }, Status = StatusMensagem.Ok };
            }

        }
        public FinancialControl Add(FinancialControl entidade)
        {
            return _repoFC.Add(entidade);
        }

        public FinancialControl Find(long id)
        {
            return _repoFC.Find(id);
        }

        public IEnumerable<FinancialControl> GetAll()
        {
            return _repoFC.GetAll();
        }

        public void Remove(FinancialControl entidade)
        {
            _repoFC.Remove(entidade);
        }

        public void Update(FinancialControl entidade)
        {
            _repoFC.Update(entidade);
        }
        public void Dispose()
        {

        }

        public IEnumerable<FinancialControl> GetByAccountId(int id)
        {
            return _repoFC.GetByAccountId(id);
        }
    }
}
