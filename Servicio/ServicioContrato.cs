using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Servicio.Contracts.Basico;
using Servicio.Contracts.Basico.ContractDefinition;

namespace Servicio
{
    public class ServicioContrato : IServicioContrato
    {
        public async Task<BigInteger> SetearNumero()
        {
            // url local
            var url = "http://localhost:7545";
            // privateKey de wallet
            var privateKey = "";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);
            
            var deployment = new BasicoDeployment();
            web3.TransactionManager.UseLegacyAsDefault = true;
            var receipt = await BasicoService.DeployContractAndWaitForReceiptAsync(web3, deployment);
            var service = new BasicoService(web3, receipt.ContractAddress);
            var receiptForSetFunctionCall = await service.SetRequestAndWaitForReceiptAsync(new SetFunction() { X = 42, Gas = 400000 });

            var intValueFromGetFunctionCall = await service.GetQueryAsync();
            return intValueFromGetFunctionCall;
        }

        public async Task<BigInteger> ObtenerNumero()
        {
            var url = "http://localhost:7545";
            var web3 = new Web3(url);
            var contractAddress = "0x9b702B09a41B7FC662ce4Ae1845e063ade76e039";
            var service = new BasicoService(web3, contractAddress);
            var currentStoredValue = await service.GetQueryAsync();
            return currentStoredValue;
        }
    }
}